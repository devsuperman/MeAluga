using Microsoft.EntityFrameworkCore;

namespace MeAluga.Models
{
    public class Contexto : DbContext
    {   
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
                
        public DbSet<Pessoa> Carros {get;set;}
        public DbSet<Imovel> Cores {get;set;} 
        public DbSet<Contrato> Pessoas {get;set;}
        
        //TODO: Seed data 
    }
}