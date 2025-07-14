using APICatalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infrastructure
{
    public class AppDbContext : DbContext
    {

        // O que está acontecendo aqui?
        // Estamos recebendo um objeto DbContextOptions<AppDbContext>, que contém as configurações
        // específicas para esse contexto (como a string de conexão, etc).
        // Esse 'options' é injetado via injeção de dependência pelo ASP.NET Core.
        // O ': base(options)' passa esse objeto para o construtor da classe base 'DbContext',
        // que usa essas opções para configurar o contexto corretamente.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; }  // Aqui estamos mapeando a entidade Category para a tabela Categories
        public DbSet<Product> Products { get; set; }   // Aqui estamos mapeando a entidade Product para a tabela Products
    }

}
