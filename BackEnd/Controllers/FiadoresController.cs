// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Dominio.Modelo;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using API.Services;
// using API.Data;
// using API.ViewModels;
// using Microsoft.AspNetCore.Authorization;
// using System;
// using API.Extensions;

// namespace API.Controllers
// {
//     [Authorize]
//     public class FiadoresController : Controller
//     {
//         private readonly Contexto db;
//         private readonly GeradorDeListas geradorDeListas;
        
//         public FiadoresController(Contexto db, GeradorDeListas geradorDeListas)
//         {
//             this.db = db;
//             this.geradorDeListas = geradorDeListas;
//         }

//         public async Task<IActionResult> Editar(string ContratoId)
//         {
//              var model = await db.Contratos.FindAsync(ContratoId);

//             if (model== null)            
//                 NotFound();            

//             if (!model.PodeEditar())            
//                 throw new InvalidOperationException("Este contrato já foi encerrado!");            

//             CarregarViewBagsAsync();
            
//             return View(model.Fiador);
//         }       

//         [HttpPost]
//         public async Task<IActionResult> Editar(Pessoa model, string ContratoId)
//         {
//             if (ModelState.IsValid)
//             {   
//                 var filter = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(ContratoId));
//                 var update = Builders<Contrato>.Update.Set(a => a.Fiador, model);

//                 await db.Contratos.UpdateOneAsync(filter, update);

//                 this.NotificarSucesso();                          
                
//                 return RedirectToAction("Detalhes", "Contratos", new {id = ContratoId});
//             }

//             CarregarViewBagsAsync();
//             return View(model);
//         }

//         [HttpPost]
//         public async Task<IActionResult> Excluir(string ContratoId)
//         {                
//             var filter = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(ContratoId));
//             var update = Builders<Contrato>.Update.Set(a => a.Fiador, null);
            
//             await db.Contratos.UpdateOneAsync(filter, update);
            
//             this.NotificarSucesso();                          

//             return RedirectToAction("Detalhes", "Contratos", new {id = ContratoId});            
//         }

//         public void CarregarViewBagsAsync() => ViewBag.EstadoCivil = geradorDeListas.EstadoCivil();

//     }
    
// }