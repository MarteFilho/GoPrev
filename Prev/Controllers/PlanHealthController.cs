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
    public class PlanHealthController : ControllerBase
    {
        private readonly DataContext _context;
        public PlanHealthController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/health")]

        public async Task<ActionResult<List<PlanHealth>>> Get()
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
        [Route("v1/health")]
        public async Task<ActionResult<PlanHealth>> Post([FromBody]PlanHealth plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Erro = "Verifique os campos digitados!" });

            try
            {
                
                _context.PlanHealths.Add(plan);


                await _context.SaveChangesAsync();


                return Ok(plan);
            }
            catch (Exception)
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados para a criação do plano!" });
            }
        }
    }
}
