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
            modelBuilder.Entity<Fiador>().OwnsOne(a => a.Endereco);

            // modelBuilder.Entity<Locatario>().HasData(
            //         new Locatario
            //         {
            //             Id = 1,
            //             Nome = "Clark Kent",
            //             DataRegistro = System.DateTime.Now,
            //             CPF = "12345678901",
            //             RG = "55555",
            //             Endereco = new Endereco("Jatuarana","10","Lagoa")
            //         },
            //         new Locatario
            //         {
            //             Id = 2,
            //             Nome = "Bruce Wayne",
            //             DataRegistro = System.DateTime.Now,
            //             CPF = "98765432198",
            //             RG = "77777",
            //             Endereco = new Endereco("Tambaqui","15","Lagoa")
            //         }
            //     );
        }        
    }
}