// using System;
// using Dominio.Modelo;
// using API.Services;
// using API.ViewModels;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using API.Data;
// using System.Collections.Generic;
// using API.Extensions;

// namespace API.Controllers
// {
//     [Authorize]
//     public class ContratosController : Controller
//     {
//         private readonly Contexto db;
//         private readonly GeradorDeListas geradorDeListas;

//         public ContratosController(Contexto db, GeradorDeListas geradorDeListas)
//         {
//             this.db = db;
//             this.geradorDeListas = geradorDeListas;
//         }

//         public async Task<IActionResult> Index()
//         {
//             var filter = Builders<Contrato>.Filter.Eq(a => a.Situacao, SituacaoDeContrato.EmAndamento);
//             var contratosEmAndamento = await db.Contratos.Find(filter).ToListAsync();
//             return View(contratosEmAndamento);
//         }

//         public async Task<IActionResult> Encerrados()
//         {
//             var filter = Builders<Contrato>.Filter.Eq(a => a.Situacao, SituacaoDeContrato.Encerrado);
//             var contratosEncerrados = await db.Contratos.Find(filter).ToListAsync();
//             return View(contratosEncerrados);
//         }

//         public async Task<IActionResult> Detalhes(string id)
//         {
//             var model = await db.Contratos.FindAsync(id);
            
//             if (model is null)            
//                 return NotFound();   

//             ViewBag.PodeEditar = model.PodeEditar();

//             return View(model);
//         }

        
//         public async Task<IActionResult> Criar()
//         {        
//             await CarregarViewBagsAsync();
//             return View();
//         }

        
//         [HttpPost]
//         public async Task<IActionResult> Criar(CriarContratoVM model)
//         {                       
//             if (ModelState.IsValid)
//             {   
//                 var filtroDeApartamento = Builders<Apartamento>.Filter.Eq(a => a.Id, ObjectId.Parse(model.ApartamentoId));
                
//                 var apartamento = await db.Apartamentos.Find(filtroDeApartamento).FirstAsync();

//                 var contrato = new Contrato(apartamento, model.Locatario, model.DataDeInicio, model.Duracao, model.ValorDoAluguel);
//                 await db.Contratos.InsertOneAsync(contrato);
                
//                 var AtualizacaoApartamento = Builders<Apartamento>.Update.Set(a => a.Situacao, "Alugado");
//                 await db.Apartamentos.UpdateOneAsync(filtroDeApartamento, AtualizacaoApartamento);

//                 this.NotificarSucesso();                          

//                 return RedirectToAction(nameof(Detalhes), new { id = contrato.Id});
//             }

//             await CarregarViewBagsAsync();
//             return View();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Encerrar(string id)
//         {
//             var filtroContrato = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(id));
//             var contrato = await db.Contratos.Find(filtroContrato).FirstAsync();            
//             var filtroApartamento = Builders<Apartamento>.Filter.Eq(a => a.Id, contrato.Apartamento.Id);
//             var apartamento = await db.Apartamentos.Find(filtroApartamento).FirstAsync();

//             if (!contrato.PodeEditar())            
//                 throw new InvalidOperationException("Este contrato já foi encerrado!");            

//             contrato.Encerrar();
//             apartamento.Desocupar();

//             await db.Contratos.ReplaceOneAsync(filtroContrato, contrato);
//             await db.Apartamentos.ReplaceOneAsync(filtroApartamento, apartamento);            
            
//             this.NotificarSucesso();                          
            
//             return RedirectToAction(nameof(Detalhes), new{ id });            
//         }

//         public async Task<IActionResult> Imprimir(string id)
//         {
//             var contrato = await db.Contratos.FindAsync(id);

//             if(!contrato.PodeImprimir())
//             {
//                 this.NotificarSucesso("Você só pode gerar o contrato após completar o cadastro do Locatário e do Fiador!");
//                 return RedirectToAction(nameof(Detalhes), new{ id });
//             };

//             return View(contrato);
//         }

//         public async Task CarregarViewBagsAsync()
//         {
//             ViewBag.ApartamentosDesocupados = await geradorDeListas.ApartamentosDesocupadosAsync();
//             ViewBag.EstadoCivil = geradorDeListas.EstadoCivil();
//         }

//     }
// }