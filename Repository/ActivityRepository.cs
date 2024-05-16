using api_web_first.Data;
using api_web_first.Models;
using book_note_app.Interfaces;
using book_note_app.Dtos.Activity;
using Microsoft.EntityFrameworkCore;
using book_note_app.Dtos.Book;
using System.Text.RegularExpressions;
using book_note_app.Helpers;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace book_note_app.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDBContext _context;
        public ActivityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> GetAllAsync(QueryObjectActivity query)
        {
            var activites = _context.Activities.Include(book => book.Book).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.sort_type))
            {
                if (query.sort_type.Equals("DESC", StringComparison.Ordinal))
                {
                    activites = activites.OrderByDescending(book => book.Id);
                }
                if (query.sort_type.Equals("ASC", StringComparison.Ordinal))
                {
                    activites = activites.OrderBy(book => book.Id);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.search))
            {
                activites = activites.Where(activity => activity.Full_name.Contains(query.search) || activity.Last_place_read.Contains(query.search));
            }

            var skipData = (query.page - 1) * query.per_page;

            return await activites.Skip((query.page - 1) * query.per_page).Take(query.per_page).ToListAsync();
        }

        public async Task<Activity> CreateActivityAsync(Activity activityModel)
        {
            await _context.Activities.AddAsync(activityModel);
            await _context.SaveChangesAsync();

            return activityModel;
        }

        public async Task<Activity> GetActvityByIdAsync(int id)
        {
            return await _context.Activities.Include(book => book.Book).SingleOrDefaultAsync(activity => activity.Id == id);
        }

        public async Task<Activity> UpdateActivityAsync(int id, Activity activityModel)
        {
            var existingActivity = await _context.Activities.FindAsync(id);

            if(existingActivity == null)
            {
                return null;
            }

            existingActivity.Full_name = activityModel.Full_name;
            existingActivity.Last_page_read = activityModel.Last_page_read;
            existingActivity.Last_place_read = activityModel.Last_place_read;
            existingActivity.Last_time_read = activityModel.Last_time_read;
            existingActivity.Result = activityModel.Result;

            await _context.SaveChangesAsync();

            return existingActivity;
        }

        public async Task<Activity> DeleteActivityAsync(int id)
        {
            var activityModel = await _context.Activities.FirstOrDefaultAsync(activity => activity.Id == id);

            if (activityModel== null)
            {
                return null;
            }

            _context.Activities.Remove(activityModel);
            await _context.SaveChangesAsync();

            return activityModel;

        }
    }
}
