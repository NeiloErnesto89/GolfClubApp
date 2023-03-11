using Microsoft.EntityFrameworkCore;
using GolfClubApp.Models;


namespace GolfClubApp.Data
{
    public class MemberContext : DbContext
    {

        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        { }

        public DbSet<GolfClubApp.Models.Member> Member { get; set; } = default!;

        public DbSet<GolfClubApp.Models.Booking> Booking { get; set; } = default!;

    }
}
