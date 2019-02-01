using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MongoDB.Driver;
using API.ViewModels;
using MongoDB.Bson;
using API.Models;
using API.Data;
using System;

namespace API.Controllers
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
            var filter = Builders<Contrato>.Filter.Eq(a => a.Situacao, SituacaoDeContrato.EmAndamento);
            var contratosEmAndamento = await db.Contratos.Find(filter).ToListAsync();
            return Ok(contratosEmAndamento);
        }

        [Route("[action]")]
        public async Task<IActionResult> Encerrados()
        {
            var filter = Builders<Contrato>.Filter.Eq(a => a.Situacao, SituacaoDeContrato.Encerrado);
            var contratosEncerrados = await db.Contratos.Find(filter).ToListAsync();
            return Ok(contratosEncerrados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var model = await db.Contratos.FindAsync(id);
            
            if (model is null)            
                return NotFound();   

            return Ok(model);
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarContratoVM model)
        {                       
            if (ModelState.IsValid)
            {   
                var filtroDeApartamento = Builders<Apartamento>.Filter.Eq(a => a.Id, ObjectId.Parse(model.ApartamentoId));
                
                var apartamento = await db.Apartamentos.Find(filtroDeApartamento).FirstAsync();

                var contrato = new Contrato(apartamento, model.Locatario, model.DataDeInicio, model.Duracao, model.ValorDoAluguel);
                await db.Contratos.InsertOneAsync(contrato);
                
                var AtualizacaoApartamento = Builders<Apartamento>.Update.Set(a => a.Situacao, "Alugado");
                await db.Apartamentos.UpdateOneAsync(filtroDeApartamento, AtualizacaoApartamento);

                return Created(nameof(Get), contrato);
            }

            return BadRequest();
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Encerrar([FromBody]string id)
        {
            var filtroContrato = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(id));
            var contrato = await db.Contratos.Find(filtroContrato).FirstAsync();            
            var filtroApartamento = Builders<Apartamento>.Filter.Eq(a => a.Id, contrato.Apartamento.Id);
            var apartamento = await db.Apartamentos.Find(filtroApartamento).FirstAsync();

            if (!contrato.PodeEditar())            
                throw new InvalidOperationException("Este contrato já foi encerrado!");            

            contrato.Encerrar();
            apartamento.Desocupar();

            await db.Contratos.ReplaceOneAsync(filtroContrato, contrato);
            await db.Apartamentos.ReplaceOneAsync(filtroApartamento, apartamento);            
            
            return Accepted(nameof(Get), contrato);            
        }
    }
}