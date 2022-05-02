using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data;
using TooManyCookbooks.Api.Data.Models;

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

        public async Task<IEnumerable<Recipe>> Get()
        {
            return await _dbContext.Recipes!.ToListAsync();
        }
    }
}