using System.Linq;
using MeAluga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly Contexto db;

        public ImoveisController(Contexto db) => this.db = db;

        [HttpGet]
        public IActionResult Get(string search)
        {
            search = (search is null ? "" : search);

            var lista = db.Imoveis.Where(w => 
                    w.Endereco.Rua.Contains(search) ||
                    w.Endereco.Numero.Contains(search) ||
                    w.Endereco.Bairro.Contains(search) ||
                    w.Endereco.Complemento.Contains(search))
                .ToList();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = db.Imoveis.Find(id);
            
            if (model is null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Add(model);
                db.SaveChanges();   

                return CreatedAtAction(nameof(Get), model);                
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Update(model);
                db.SaveChanges();
                return Accepted(model);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = db.Imoveis.Find(id);
            db.Imoveis.Remove(model);
            db.SaveChanges();

            return NoContent();
        }
    }
}
