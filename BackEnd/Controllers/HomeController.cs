// using MAPI.ata;
// using System.Diagnostics;
// using API.ViewModels;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;

// namespace template.Controllers
// {
//     [Authorize]
//     public class HomeController : Controller
//     {
//         private readonly Contexto db;

//         public HomeController(Contexto db)
//         {
//             this.db = db;
//         }

//         public async Task<IActionResult> Index()
//         {            
//             var contratos = await db.Contratos.ListarTodosAsync();
//             var painel = new PainelVM(contratos);            
//             return View(painel);
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//         }
//     }
// }
