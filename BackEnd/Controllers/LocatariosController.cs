// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using Dominio.Modelo;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using API.Data;
// using API.Services;
// using API.ViewModels;
// using Microsoft.AspNetCore.Authorization;
// using API.Extensions;

// namespace API.Controllers
// {
//     [Authorize]
//     public class LocatariosController : Controller
//     {
//         private readonly Contexto db;
//         private readonly GeradorDeListas geradorDeListas;
        
//         public LocatariosController(Contexto db, GeradorDeListas geradorDeListas)
//         {
//             this.db = db;
//             this.geradorDeListas = geradorDeListas;
//         }

//         public async Task<IActionResult> Editar(string ContratoId)
//         {
//              var model = await db.Contratos.FindAsync(ContratoId);

//             if (model== null)            
//                 NotFound();            

//             CarregarViewBagsAsync();
            
//             return View(model.Locatario);
//         }       

//         [HttpPost]
//         public async Task<IActionResult> Editar(Pessoa model, string ContratoId)
//         {
//             if (ModelState.IsValid)           
//             {                   
//                 var filter = Builders<Contrato>.Filter.Eq(a => a.Id, ObjectId.Parse(ContratoId));
//                 var update = Builders<Contrato>.Update.Set(a => a.Locatario, model);

//                 await db.Contratos.UpdateOneAsync(filter, update);
                
//                 this.NotificarSucesso();                          
                
//                 return RedirectToAction("Detalhes", "Contratos", new {id = ContratoId});
//             }

//             CarregarViewBagsAsync();
//             return View(model);
//         }

//         public void CarregarViewBagsAsync() => ViewBag.EstadoCivil = geradorDeListas.EstadoCivil();

//     }
    
// }