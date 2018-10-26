using System.Linq;
using MeAluga.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosCivisController : ControllerBase
    {
        private readonly Contexto db;

        public EstadosCivisController(Contexto db) => this.db = db;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await db.EstadosCivis.ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await db.Locatarios.FindAsync(id);
            
            if (model is null)
                return NotFound();

            return Ok(model);
        }      
    }
}
