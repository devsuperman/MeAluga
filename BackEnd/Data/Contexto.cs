using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using API.Models;
using MongoDB.Bson;

namespace API.Data
{
    public class Contexto
    {
        private readonly IConfiguration _configuration;        
        public IMongoCollection<Usuario> Usuarios {get; private set;}
        public IMongoCollection<Contrato> Contratos {get; private set;}
        public IMongoCollection<Apartamento> Apartamentos {get; private set;}
        
        public Contexto(IConfiguration config)
        {
            _configuration = config;

            var client = new MongoClient(_configuration.GetConnectionString("localhost"));
            
            var db = client.GetDatabase("mealuga");

            Contratos = db.GetCollection<Contrato>("contratos");
            Apartamentos = db.GetCollection<Apartamento>("apartamentos");
            Usuarios = db.GetCollection<Usuario>("usuarios");
        }
    }

    public static class IMongoCollectionExtension
    {
        public static async Task ExcluirAsync<T>(this IMongoCollection<T> collection, string id) where T : class
        {
            var filtro = FiltroPorId<T>(id);
            await collection.DeleteOneAsync(filtro);
        }

        public static async Task<T> FindAsync<T>(this IMongoCollection<T> collection, string id) where T : class
        {
            var filtro = FiltroPorId<T>(id);
            return await collection.Find(filtro).FirstOrDefaultAsync();
        }

        public static async Task<IList<T>> ListarTodosAsync<T>(this IMongoCollection<T> collection) where T : class
        {            
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public static async Task Atualizar<T>(this IMongoCollection<T> collection, string id, T objetoNovo) where T : class
        {            
            var filtro = FiltroPorId<T>(id);
            await collection.ReplaceOneAsync(filtro, objetoNovo);
        }

        private static FilterDefinition<T> FiltroPorId<T>(string id) where T : class
        {
            return Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));    
        }
    }   
}
