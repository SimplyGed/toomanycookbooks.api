using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data.Models;

namespace TooManyCookbooks.Api.Data
{
    public class TmcbDbContext : DbContext
    {
        public TmcbDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TmcbDbContext()
        {
        }

        public DbSet<Book>? Books { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }
        public DbSet<Recipe>? Recipes { get; set; }
    }
}