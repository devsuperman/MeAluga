using System.Linq;
using MeAluga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatariosController : ControllerBase
    {
        private readonly Contexto db;

        public LocatariosController(Contexto db) => this.db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await db.Locatarios.ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await db.Locatarios.FindAsync(id);
            
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Locatario model)
        {
            if (ModelState.IsValid)
            {
                await db.Locatarios.AddAsync(model);
                await db.SaveChangesAsync();   

                return Created(nameof(Get), model);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Locatario model)
        {
            if (ModelState.IsValid)
            {
                db.Locatarios.Update(model);
                await db.SaveChangesAsync();
                return Accepted(model);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await db.Locatarios.FindAsync(id);
            db.Locatarios.Remove(model);
            await db.SaveChangesAsync();

            return NoContent();
        }
    }
}
