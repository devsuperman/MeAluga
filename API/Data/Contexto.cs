using Microsoft.EntityFrameworkCore;

namespace MeAluga.Models
{
    public class Contexto : DbContext
    {   
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }
                
        public DbSet<Locatario> Locatarios  {get;set;}
        public DbSet<Imovel> Imoveis {get;set;} 
        public DbSet<Contrato> Contratos {get;set;}        
        
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Imovel>().OwnsOne(a => a.Endereco);                      
        }        
    }
}