using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data;

namespace TooManyCookbooks.Api.Contollers
{
    [Route("/api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly TmcbDbContext _dbContext;

        public RecipesController(TmcbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
    }
}