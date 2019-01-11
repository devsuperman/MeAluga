using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API.ViewModels;
using MongoDB.Driver;
using MongoDB.Bson;
using API.Models;
using API.Data;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentosController : ControllerBase
    {
        private readonly Contexto db;

        public ApartamentosController(Contexto db) => this.db = db;

        [HttpGet]
        public async Task<IActionResult> Get(bool? desocupado)
        {            
            var lista = await db.Apartamentos.ListarTodosAsync();          

            if (desocupado.HasValue)            
                lista = lista.Where(w => w.Situacao == SituacaoDeApartamento.Desocupado).ToList();            

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var model = await db.Apartamentos.FindAsync(id);          
            
            if (model is null)            
                return NotFound();
            
            return Ok(model);
        }
  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApartamentoVM viewmodel)
        {                       
            if (ModelState.IsValid)
            {   
                var apartamento = new Apartamento(viewmodel.Endereco, viewmodel.Apelido);
                await db.Apartamentos.InsertOneAsync(apartamento);
                return Created(nameof(Get), apartamento);
            }

            return BadRequest();
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ApartamentoVM viewmodel)
        {                       
            if (ModelState.IsValid)
            {
                await AtualizarApartamentosDosContratos(viewmodel);
                await AtualizarApartamento(viewmodel);
                return Accepted(nameof(Get), viewmodel);
            }

            return BadRequest();
        }

        private async Task AtualizarApartamentosDosContratos(ApartamentoVM viewmodel)
        {
            var filter = Builders<Contrato>.Filter.Eq(a => a.Apartamento.Id, ObjectId.Parse(viewmodel.Id));

            var update = Builders<Contrato>.Update
                .Set(a => a.Apartamento.Apelido, viewmodel.Apelido)
                .Set(a => a.Apartamento.Endereco, viewmodel.Endereco);

            await db.Contratos.UpdateManyAsync(filter, update);
        }

        private async Task AtualizarApartamento(ApartamentoVM viewmodel)
        {
            var filter = Builders<Apartamento>.Filter.Eq(a => a.Id, ObjectId.Parse(viewmodel.Id));
            
            var update = Builders<Apartamento>.Update
                .Set(a => a.Apelido, viewmodel.Apelido)
                .Set(a => a.Endereco, viewmodel.Endereco);

            await db.Apartamentos.UpdateOneAsync(filter, update);
        }
    }
}