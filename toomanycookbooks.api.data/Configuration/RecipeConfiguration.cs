using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data.Models;

namespace TooManyCookbooks.Api.Data.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();

            builder.HasOne(b => b.Book).WithMany();
        }
    }
}