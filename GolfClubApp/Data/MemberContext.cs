using Microsoft.EntityFrameworkCore;


namespace GolfClubApp.Data
{
    public class MemberContext : DbContext
    {

        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        { }

        public DbSet<GolfClubApp.Models.Member> Member { get; set; } = default!;

    }
}
