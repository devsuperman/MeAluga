using System.Linq;
using MeAluga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatariosController : ControllerBase
    {
        private readonly Contexto db;

        public LocatariosController(Contexto db) => this.db = db;

        [HttpGet]
        public ActionResult<IEnumerable<Locatario>> Get(string search)
        {
            search = (search is null ? "" : search.ToLower());

            var lista = db.Locatarios.Where(w => 
                    w.Nome.ToLower().Contains(search) ||
                    w.CPF.ToLower().Contains(search))                    
                .ToList();

            return lista;
        }

        [HttpGet("{id}")]
        public ActionResult<Locatario> Get(int id)
        {
            var model = db.Locatarios.Find(id);
            
            if (model is null)
                return NotFound();

            return model;
        }

        [HttpPost]
        public void Post([FromBody] Locatario model)
        {
            if (ModelState.IsValid)
            {
                db.Locatarios.Add(model);
                db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Locatario model)
        {
            if (ModelState.IsValid)
            {
                db.Locatarios.Update(model);
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = db.Locatarios.Find(id);
            db.Locatarios.Remove(model);
            db.SaveChanges();
        }
    }
}
