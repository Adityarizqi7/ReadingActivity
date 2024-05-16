using api_web_first.Models;
using book_note_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace api_web_first.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                    .HasMany(e => e.Genres)
                    .WithMany(e => e.Books)
                    .UsingEntity<BookGenre>();

            builder.Entity<Genre>()
                    .HasMany(e => e.Books)
                    .WithMany(e => e.Genres)
                    .UsingEntity<BookGenre>();

            //builder.Entity<BookGenre>()
            //.HasKey(bg => new { bg.BookId, bg.GenreId });

            //builder.Entity<BookGenre>()
            //    .HasOne(bg => bg.Book)
            //    .WithMany(b => b.BookGenres)
            //    .HasForeignKey(bg => bg.BookId);

            //builder.Entity<BookGenre>()
            //    .HasOne(bg => bg.Genre)
            //    .WithMany(g => g.BookGenres)
            //    .HasForeignKey(bg => bg.GenreId);
        }
    }
}
