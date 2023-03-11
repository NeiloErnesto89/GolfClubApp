using Microsoft.EntityFrameworkCore;


namespace GolfClubApp.Data
{
    public class BookingContext : DbContext
    {

        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        { }

        public DbSet<GolfClubApp.Models.Booking> Booking { get; set; } = default!;
    }
}
