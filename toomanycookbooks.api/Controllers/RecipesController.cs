using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data;
using TooManyCookbooks.Api.Data.Models;

namespace TooManyCookbooks.Api.Contollers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly TmcbDbContext _dbContext;

        public RecipesController(TmcbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var recipes = await _dbContext.Recipes!.Include(r => r.Book).ToListAsync();

            var response = recipes.Select(r => new
            {
                r.Id,
                r.Name,
                Author = r.Book!.Author,
                Book = r.Book!.Title
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Recipe recipe)
        {
            var book = _dbContext.Books!.First();

            recipe.BookId = book.Id;

            _dbContext.Recipes!.Add(recipe);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}