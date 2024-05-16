using api_web_first.Data;
using book_note_app.Dtos.Book;
using book_note_app.Helpers;
using book_note_app.Interfaces;
using book_note_app.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace book_note_app.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBookRepository _bookRepo;

        public BookController(ApplicationDBContext context, IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectBook query)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var books = await _bookRepo.GetAllAsync(query);
            var bookDot = books.Select(book => book.ToBookDto());

            var count_items = await _context.Books.CountAsync();

            return Ok(new
            {
                data = bookDot,
                meta = new
                {
                    pagination = new
                    {
                        total_items_all_page = count_items,
                        total_items_current_page = books.Count(),
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

            var book = await _bookRepo.GetBookBySlugAsync(slug);

            if (book == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Book doesn't exist!",
                        code = 400
                    }
                });
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookModel = bookDto.ToBookFromCreateDTO();

            bookModel.Author = bookModel.Author.ToUpper();
            bookModel.Slug = Regex.Replace(bookDto.Title, @"[^\w\s]", "").ToLower().Replace(" ", "-");

            bookModel.Created_at = DateTime.Now;
            bookModel.Updated_at = DateTime.Now;

            await _bookRepo.CreateBookAsync(bookModel);

            return CreatedAtAction(nameof(GetBySlug), new { slug = bookModel.Slug, id = bookModel.Id }, bookModel.ToBookDto());
            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookModel = await _bookRepo.UpdateBookAsync(id, updateDto);

            if (bookModel == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Book doesn't exist!",
                        code = 400
                    }
                });
            }

            bookModel.Updated_at = DateTime.Now;

            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var bookModel = await _bookRepo.DeleteBookAsync(id);

            if (bookModel == null)
            {
                return NotFound(new
                {
                    error = new
                    {
                        message = "Book doesn't exist!",
                        code = 400
                    }
                });
            }

            return Ok(new
            {
                message = "Book has been deleted."
            });

        }
    }
}
