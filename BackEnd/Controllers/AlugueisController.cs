// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;
// using API.ViewModels;
// using Dominio.Modelo;
// using MongoDB.Driver;
// using MongoDB.Bson;
// using API.Data;
// using System.Linq;
// using System;
// using API.Extensions;

// namespace API.Controllers
// {
//     [Authorize]
//     public class AlugueisController : Controller
//     {
//         private readonly Contexto db;

//         public AlugueisController(Contexto db)
//         {
//             this.db = db;
//         }

//         public async Task<IActionResult> Index()
//         {            
//             var filter = Builders<Contrato>.Filter.Eq(a => a.Situacao, SituacaoDeContrato.EmAndamento);

//             var contratosEmAndamento = await db.Contratos.Find(filter).ToListAsync();

//             var daquiTrintaDias = DateTime.Today.AddDays(30);

//             var alugueis = contratosEmAndamento
//                 .SelectMany(a => a.Alugueis, (contrato, aluguel) => new AluguelVM(contrato, aluguel))
//                 .Where(a => 
//                     a.Vencimento <= daquiTrintaDias &&
//                     a.Situacao == SituacaoDeAluguel.EmAberto)
//                 .OrderBy(a => a.Vencimento);

//             return View(alugueis);
//         }

//         public async Task<IActionResult> RegistrarPagamento(string Id)
//         {
//             var filter = Builders<Contrato>.Filter.Eq("Alugueis.Id", Id);

//             var contrato = await db.Contratos.Find(filter).FirstOrDefaultAsync();
            
//             if (contrato is null)            
//                 NotFound();            

//             if (!contrato.PodeEditar())
//                 throw new InvalidOperationException("Este contrato já foi encerrado!");            
            
//             var aluguel = contrato.Alugueis.FirstOrDefault(a => a.Id == Id);

//             var viewmodel = new PagamentoDeAluguelVM(aluguel, contrato);

//             return View(viewmodel);
//         }       

//         [HttpPost]
//         public async Task<IActionResult> RegistrarPagamento(PagamentoDeAluguelVM model)
//         {            
//             if (ModelState.IsValid)
//             {   
//                 var filter = Builders<Contrato>.Filter.Eq("Alugueis.Id", model.Id);
                
//                 var update = Builders<Contrato>.Update
//                     .Set("Alugueis.$.ValorPago", model.ValorPago)
//                     .Set("Alugueis.$.Observacao", model.Observacao)
//                     .Set("Alugueis.$.Situacao", "Pago")
//                     .Set("Alugueis.$.DataDePagamento", model.DataDePagamento);
                
//                 await db.Contratos.UpdateOneAsync(filter, update);     
//                 this.NotificarSucesso();                          

//                 return RedirectToAction("Detalhes", "Contratos", new {id = model.ContratoId});
//             }

//             return View(model);
//         }

//         public async Task<IActionResult> Recibo(string Id)
//         {
//             var filter = Builders<Contrato>.Filter.Eq("Alugueis.Id", Id);

//             var contrato = await db.Contratos.Find(filter).FirstOrDefaultAsync();
            
//             if (contrato is null)            
//                 NotFound();            
            
//             var aluguel = contrato.Alugueis.FirstOrDefault(a => a.Id == Id);

//             var viewmodel = new ReciboVM(aluguel, contrato);

//             return View(viewmodel);
//         }   

//     }
    
// }