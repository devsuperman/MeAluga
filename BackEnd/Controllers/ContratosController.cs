using System.Linq;
using MeAluga.Models;
using MeAluga.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly Contexto db;

        public ContratosController(Contexto db) => this.db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await db.Contratos
                .Include("Locatario")                
                .Include("Imovel")
                .Select(contrato => new ListarContratosViewModel(contrato))
                .ToListAsync();            

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await db.Contratos
                .Include(a => a.Alugueis)                
                .Include(a => a.Locatario)                
                .Include(a => a.Imovel)                
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (model is null)
                return NotFound();

            var viewmodel = new ContratoVM(model);

            return Ok(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarContratoViewModel model)
        {   
            var imovel = await db.Imoveis.Include(a => a.Contratos).SingleOrDefaultAsync(a => a.Id == model.ImovelId);

            if (imovel.Alugado())            
                ModelState.AddModelError("", "O imóvel já está alugado");            

            if (ModelState.IsValid)
            {   
                var contrato = new Contrato(model.ImovelId, model.Locatario, model.DataDeInicio, model.Duracao, model.ValorDoAluguel);
                await db.Contratos.AddAsync(contrato);
                await db.SaveChangesAsync();   

                return Created(nameof(Get), model);
            }

            return BadRequest();
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] Contrato model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         db.Contratos.Update(model);
        //         await db.SaveChangesAsync();
        //         return Accepted(model);
        //     }

        //     return BadRequest();
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var model = await db.Contratos.FindAsync(id);
        //     db.Contratos.Remove(model);
        //     await db.SaveChangesAsync();

        //     return NoContent();
        // }
    }
}
