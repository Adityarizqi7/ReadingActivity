using api_web_first.Models;
using book_note_app.Dtos.Activity;
using book_note_app.Helpers;

namespace book_note_app.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAllAsync(QueryObjectBook query);
        Task<Activity> GetActvityByIdAsync(int id);
        Task<Activity> CreateActivityAsync(Activity activityModel);
        Task<Activity> UpdateActivityAsync(int id, Activity activityModel);
        Task<Activity> DeleteActivityAsync(int id);
    }
}
