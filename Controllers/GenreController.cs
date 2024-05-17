using api_web_first.Data;
using book_note_app.Dtos.Book;
using book_note_app.Dtos.Genre;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using book_note_app.Mappers;
using book_note_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug([FromRoute] string slug)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var genre = await _genreRepo.GetGenreBySlugAsync(slug);

            if (genre == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Genre doesn't exist!",
                        code = 400
                    }
                });
            }

            return Ok(genre.ToGenreDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGenreRequestDto genreDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var genreModel = genreDto.ToGenreFromCreateDTO();

            genreModel.Name = genreModel.Name;
            genreModel.Slug = Regex.Replace(genreDto.Name, @"[^\w\s-]", "").ToLower().Replace(" ", "-");
            genreModel.Created_at = DateTime.Now;
            genreModel.Updated_at = DateTime.Now;

            await _genreRepo.CreateGenreAsync(genreModel);

            return CreatedAtAction(nameof(GetBySlug), new { slug = genreModel.Slug, id = genreModel.Id }, genreModel.ToGenreDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGenreRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var genreModel = await _genreRepo.UpdateGenreAsync(id, updateDto);

            if (genreModel == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Genre doesn't exist!",
                        code = 400
                    }
                });
            }

            return Ok(genreModel.ToGenreDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookModel = await _genreRepo.DeleteGenreAsync(id);

            if (bookModel == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Genre doesn't exist!",
                        code = 400
                    }
                });
            }

            return Ok(new
            {
                message = "Genre has been deleted."
            });

        }
    }
}
