using System.Linq;
using MeAluga.Models;
using MeAluga.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly Contexto db;

        public ImoveisController(Contexto db) => this.db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await db.Imoveis
                .Include("Contratos")
                .Select(imovel => new ListarImoveisViewModel(imovel))
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await db.Imoveis.FindAsync(id);
            
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                await db.Imoveis.AddAsync(model);
                await db.SaveChangesAsync();   

                return Created(nameof(Get), model);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Update(model);
                await db.SaveChangesAsync();
                return Accepted(model);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.Imoveis.FindAsync(id);
            db.Imoveis.Remove(model);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
