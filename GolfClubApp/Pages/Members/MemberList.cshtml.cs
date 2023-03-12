using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using GolfClubApp.Models;

namespace GolfClubApp.Pages.Members
{
    public class MemberListModel : PageModel
    {

        private readonly GolfClubApp.Data.MemberContext _context;
        public IEnumerable<Member> Member { get; set; } = default!;

        public MemberListModel(GolfClubApp.Data.MemberContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }

        //public void OnGet()
        //{
        //}
    }
}
