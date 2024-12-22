using Ecom_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom_Store.SqlContext
{
    public class sqlcontext:DbContext
    {

        public sqlcontext(DbContextOptions<sqlcontext> option) : base(option)
        {

        }

        public DbSet<Contactmodel> ContactTable { get; set; }
        public DbSet<FeedbackForm> FeedbackTable { get; set; }
        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<RegisterModel> RegisterModel { get; set; }
        public DbSet<ShopsModel> ShopsModel { get; set; }
        public DbSet<FoodCourtModel> FoodCourtModel { get; set; }

       

        public DbSet<CinemaModel> CinemaModel { get; set; } = default!;
        public DbSet<BookedSeats> BookedSeats { get; set; } = default!;
        public DbSet<MoviesModel> MoviesModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookedSeats>()
                .HasOne(b => b.Movies)
                .WithMany()
                .HasForeignKey(b => b.MovieID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BookedSeats>()
                .HasOne(b => b.Cinema)
                .WithMany()
                .HasForeignKey(b => b.CinemaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

    }
}
