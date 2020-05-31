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

        public async Task<ActionResult<Plan>> Post([FromBody]Plan plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Erro = "Verifique os campos digitados!" });

            try
            {
                _context.Plan.Add(plan);
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
