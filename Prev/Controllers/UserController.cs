﻿using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var users = await _context.User.AsNoTracking().ToListAsync();

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
      

    }
}
