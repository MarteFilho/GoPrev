using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prev.Context;
using Prev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Prev.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/user")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _context.User.AsNoTracking().ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("v1/user")]

        public async Task<ActionResult<User>> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Erro = "Verifique os campos digitados!" });

            try
            {
                
                
                    var code = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var random = new Random();
                    var usercode = new string(
                        Enumerable.Repeat(code, 8)
                                  .Select(s => s[random.Next(s.Length)])
                                  .ToArray());
                user.UserCode = usercode;

                _context.User.Add(user);
                await _context.SaveChangesAsync();

                if (user.Codeaffiliate != null)
                {

                    try
                    {
                        var ownerCode = await _context.User.Where(x => x.UserCode == user.Codeaffiliate).FirstOrDefaultAsync();
                        if (ownerCode == null)
                            return NotFound(new { Erro = "Usuário dono do código não foi encontrado!" });

                        ownerCode.Points = ownerCode.Points + 100;
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    catch (Exception)
                    {
                        return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a validação do código!" });
                    }
                }

                return Ok(user);


            }

            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a criação do usuário!" });
            }
        }


        [HttpPost]
        [Route("v1/login")]
        public async Task<ActionResult<dynamic>> Login([FromBody]User model)
        {
            try
            {
                var user = await _context.User.AsNoTracking().Where(x => x.CPF == model.CPF && x.Password == model.Password).FirstOrDefaultAsync();

                if (user == null)
                    return NotFound(new {Erro = "Usuário ou senha inválidos!" });
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a criação do usuário!" });
            }

          

        }

        [HttpPut]
        [Route("v1/login")]
        public async Task<ActionResult<dynamic>> Edit([FromBody]User model)
        {
            try
            {
                _context.Entry<User>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
