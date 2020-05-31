using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prev.Context;
using Prev.Models;
using System;
using System.Collections.Generic;
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
            try
            {
                var users = await _context.User.AsNoTracking().ToListAsync();

                if (users == null)
                    return NotFound(new { Erro = "Não foi encontrado nenhum usuário!" });
                return Ok(users);


            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível buscar os usuários" });
            }
        }


        [HttpPost]
        [Route("v1/user")]

        public async Task<ActionResult<User>> Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Erro = "Verifique os campos digitados!" });

            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a criação do usuário!" });
            }
        }

      

    }
}
