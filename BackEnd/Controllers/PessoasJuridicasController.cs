// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using API.Extensions;
// using Dominio.Modelo;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using API.Data;
// using System;

// namespace API.Controllers
// {
//     [Authorize]
//     public class PessoasJuridicasController : Controller
//     {
//         private readonly Contexto db;

//         public PessoasJuridicasController(Contexto db) => this.db = db;

//         public async Task<IActionResult> Editar(string ContratoId)
//         {
//              var model = await db.Contratos.FindAsync(ContratoId);

//             if (model== null)            
//                 NotFound();            

//             if (!model.PodeEditar())            
//                 throw new InvalidOperationException("Este contrato já foi encerrado!");            
            
//             return View(model.PessoaJuridica);
//         }       

//         [HttpPost]
//         public async Task<IActionResult> Editar(PessoaJuridica model, string ContratoId)
//         {
//             if (ModelState.IsValid)
//             {               

//                 var filter = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(ContratoId));
//                 var update = Builders<Contrato>.Update.Set(a => a.PessoaJuridica, model);

//                 await db.Contratos.UpdateOneAsync(filter, update);

//                 this.NotificarSucesso();                          
                
//                 return RedirectToAction("Detalhes", "Contratos", new {id = ContratoId});
//             }

//             return View(model);
//         }

//         [HttpPost]
//         public async Task<IActionResult> Excluir(string ContratoId)
//         {                
//             var filter = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(ContratoId));
//             var update = Builders<Contrato>.Update.Set(a => a.PessoaJuridica, null);
            
//             await db.Contratos.UpdateOneAsync(filter, update);
            
//             this.NotificarSucesso();                          

//             return RedirectToAction("Detalhes", "Contratos", new {id = ContratoId});            
//         }        

//     }
    
// }