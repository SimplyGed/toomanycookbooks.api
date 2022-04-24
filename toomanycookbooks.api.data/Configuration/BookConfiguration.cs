using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data.Models;

namespace TooManyCookbooks.Api.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Author).IsRequired();
        }
    }
}