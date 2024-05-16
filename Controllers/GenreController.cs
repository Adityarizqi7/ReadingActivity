using api_web_first.Data;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using book_note_app.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book_note_app.Controllers
{
    [Route("api/genres")]
    [ApiController]

    public class GenreController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IGenreRepository _genreRepo;

        public GenreController(ApplicationDBContext context, IGenreRepository genreRepo)
        {
            _context = context;
            _genreRepo = genreRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectGenre query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var genres = await _genreRepo.GetAllAsync(query);
            var genreDto = genres.Select(genre => genre.ToGenreDto());

            var count_items = await _context.Genres.CountAsync();

            return Ok(new
            {
                data = genreDto,
                meta = new
                {
                    pagination = new
                    {
                        total_items_all_page = count_items,
                        total_items_current_page = genreDto.Count(),
                        limit_item_per_page = query.per_page,
                        total_pages = (int)Math.Ceiling(count_items / (double)query.per_page)
                    }

                }
            });
        }
    }
}
