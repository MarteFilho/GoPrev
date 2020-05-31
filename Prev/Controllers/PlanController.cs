using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prev.Context;
using Prev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prev.Controllers
{
    public class PlanController : ControllerBase
    {

        private readonly DataContext _context;
        public PlanController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/plan")]

        public async Task<ActionResult<List<Plan>>> Get()
        {
            try
            {
                var plans = await _context.Plan.AsNoTracking().ToListAsync();

                if (plans == null)
                    return NotFound(new { Erro = "Não foi encontrado nenhum plano!" });
                return Ok(plans);

            }



            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível buscar os planos!" });
            }
        }

        [HttpPost]
        [Route("v1/plan")]
        public async Task<ActionResult<Plan>> Post([FromBody]Plan plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Erro = "Verifique os campos digitados!" });

            try
            {
                Random randNum = new Random();
                var numero = randNum.Next(200);
                plan.Code = numero;
                plan.StartDate = System.DateTime.Today;
                _context.Plan.Add(plan);


                await _context.SaveChangesAsync();


                return Ok(plan);
            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a criação do plano!" });
            }
        }


        [HttpPost]
        [Route("v1/plan/target")]
        public async Task<ActionResult<List<Plan>>> GetByTarget([FromBody]User user)
        {
            try
            {
                var plans = await _context.Plan.AsNoTracking().Where(x => x.Target == user.Target).ToListAsync();

                if (plans == null)
                    return NotFound(new { Erro = "Não foi encontrado nenhum plano para seu perfil!" });
                return Ok(plans);

            }



            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível buscar os planos!" });
            }
        }

        [HttpPut]
        [Route("v1/plan/adduser/{id:int}")]
        public async Task<ActionResult<List<Plan>>> GetByTarget(int id, [FromBody]User user)
        {
            if (id != user.Id)
                return NotFound(new { Erro = "Usuário não encontrado!" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(user);

            }
            catch (Exception)
            {

                return BadRequest(new { erro = "Não foi possível adicionar o usuário ao plano!" });
            }
        }

    }
}
