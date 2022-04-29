namespace TooManyCookbooks.Api.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Author { get; set; }
    }

    public class Recipe
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }

        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
    }

    public class Ingredient
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
    }
}