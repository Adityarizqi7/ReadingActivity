 using api_web_first.Data;
using book_note_app.Mappers;
using book_note_app.Interfaces;
using Microsoft.AspNetCore.Mvc;
using book_note_app.Dtos.Activity;
using api_web_first.Models;
using book_note_app.Helpers;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore;

namespace book_note_app.Controllers
{
    [Route("api/activities")]
    [ApiController]

    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IActivityRepository _activityRepo;
        private readonly IBookRepository _bookRepo;

        public ActivityController(ApplicationDBContext context, IActivityRepository activityRepo, IBookRepository bookRepo)
        {
            _activityRepo = activityRepo;
            _bookRepo = bookRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectActivity query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var activities = await _activityRepo.GetAllAsync(query);
            var activityDto = activities.Select(s => s.ToActivityWithBookDto());

            var count_items = await _context.Activities.CountAsync();

            return Ok(new
            {
                data = activityDto,
                meta = new
                {
                    pagination = new
                    {
                        total_items_all_page = count_items,
                        total_items_current_page = activities.Count(),
                        limit_item_per_page = query.per_page,
                        total_pages = (int)Math.Ceiling(count_items / (double)query.per_page)
                    }

                }
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var activity = await _activityRepo.GetActvityByIdAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity.ToActivityWithBookDto());
        }

        [HttpPost("{book_id:int}")]
        public async Task<IActionResult> Create([FromRoute] int book_id, CreateActivityDto activityDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _bookRepo.BookExist(book_id))
            {
                var error_message = new
                {
                    error = new
                    {
                        message = "Book doesn't not exist, Go Create Book!"
                    }
                };
                return BadRequest(error_message);
            }

            var activityModel = activityDto.ToActivityFromCreate(book_id);

            activityModel.Created_at = DateTime.Now;
            activityModel.Updated_at = DateTime.Now;

            await _activityRepo.CreateActivityAsync(activityModel);

            return CreatedAtAction(nameof(GetById), new { id = activityModel.Id }, activityModel.ToActivityDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateActivityRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var activity = await _activityRepo.UpdateActivityAsync(id, updateDto.ToActivityFromUpdate());

            if (activity == null)
            {
                return NotFound("Activity not found.");
            }

            activity.Updated_at = DateTime.Now;

            return Ok(activity.ToActivityDto());
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var activityModel = await _activityRepo.DeleteActivityAsync(id);

            if (activityModel == null)
            {
                return NotFound("Activity does not exits!");
            }

            return Ok(activityModel);
        }
    }
}
