using TooManyCookbooks.Api.Data.Models;

namespace TooManyCookbooks.Api.Data
{
    public static class DataSeed
    {
        public static async Task AddAsync(TmcbDbContext dbContext)
        {
            if (dbContext.Books!.Any())
            {
                return;
            }

            for (int b = 1; b <= 4; b++)
            {
                var book = new Book { Author = $"Author {b % 3}", Title = $"Cookbook {b + 1}" };

                dbContext.Books!.Add(book);

                for (var r = 1; r <= 2; r++)
                {
                    var recipe = new Recipe { BookId = book.Id, Book = book, Name = $"Recipe {b}-{r}" };

                    for (int i = 1; i <= 3; i++)
                    {
                        var ingredient = new Ingredient { Name = $"Ingredient {r}-{i}" };

                        dbContext.Ingredients!.Add(ingredient);

                        recipe.Ingredients!.Add(ingredient);
                    }

                    dbContext.Recipes!.Add(recipe);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}