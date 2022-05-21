using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TooManyCookbooks.Api.Data;

namespace TooManyCookbooks.Api.Contollers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly TmcbDbContext _dbContext;

        public BooksController(TmcbDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _dbContext.Books!.ToListAsync();

            return Ok(books);
        }
    }
}