using api_web_first.Models;
using book_note_app.Dtos.Activity;
using book_note_app.Dtos.Book;

namespace book_note_app.Mappers
{
    public static class ActivityMappers
    {
        public static ActivityDto ToActivityDto(this Activity activityModel)
        {
            return new ActivityDto
            {
                Id = activityModel.Id,
                Full_name = activityModel.Full_name,
                Last_page_read = activityModel.Last_page_read,
                Last_place_read = activityModel.Last_place_read,
                Last_time_read = activityModel.Last_time_read,
                Result = activityModel.Result,
                Created_at = activityModel.Created_at,
                Updated_at = activityModel.Updated_at,
            };
        }

        public static ActivityDto ToActivityWithBookDto(this Activity activityModel)
        {
            return new ActivityDto
            {
                Id = activityModel.Id,
                Full_name = activityModel.Full_name,
                Last_page_read = activityModel.Last_page_read,
                Last_place_read = activityModel.Last_place_read,
                Last_time_read = activityModel.Last_time_read,
                Result = activityModel.Result,
                Created_at = activityModel.Created_at,
                Updated_at = activityModel.Updated_at,
                Book =  new BookWithActivityDto
                {
                    Id = activityModel.Book.Id,
                    Title = activityModel.Book.Title,
                    Slug = activityModel.Book.Slug,
                    Author = activityModel.Book.Author,
                    Total_pages = activityModel.Book.Total_pages,
                }
            };
        }

        public static Activity ToActivityFromCreate(this CreateActivityDto activityDto, int bookId)
        {
            return new Activity
            {
                Full_name = activityDto.Full_name,
                Last_page_read = activityDto.Last_page_read,
                Last_place_read = activityDto.Last_place_read,
                Last_time_read = activityDto.Last_time_read,
                Result = activityDto.Result,
                BookId = bookId
            };
        }

        public static Activity ToActivityFromUpdate(this UpdateActivityRequestDto activityDto)
        {
            return new Activity
            {
                Full_name = activityDto.Full_name,
                Last_page_read = activityDto.Last_page_read,
                Last_place_read = activityDto.Last_place_read,
                Last_time_read = activityDto.Last_time_read,
                Result = activityDto.Result
            };
        }
    }
}
