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
        public ActionResult<IEnumerable<Imovel>> Get(string search)
        {
            search = (search is null ? "" : search.ToLower());

            var lista = db.Imoveis.Where(w => 
                    w.Endereco.Rua.ToLower().Contains(search) ||
                    w.Endereco.Numero.ToLower().Contains(search) ||
                    w.Endereco.Bairro.ToLower().Contains(search) ||
                    w.Endereco.Complemento.ToLower().Contains(search))
                .ToList();

            return lista;
        }

        [HttpGet("{id}")]
        public ActionResult<Imovel> Get(int id)
        {
            var model = db.Imoveis.Find(id);
            
            if (model is null)
                return NotFound();

            return model;
        }

        [HttpPost]
        public void Post([FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Add(model);
                db.SaveChanges();                
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Imovel model)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Update(model);
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = db.Imoveis.Find(id);
            db.Imoveis.Remove(model);
            db.SaveChanges();
        }
    }
}
