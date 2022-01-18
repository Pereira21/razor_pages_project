#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSoccer.Data;
using RazorPagesSoccer.Models;

namespace RazorPagesSoccer.Pages.Clubs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSoccer.Data.RazorPagesSoccerContext _context;

        public IndexModel(RazorPagesSoccer.Data.RazorPagesSoccerContext context)
        {
            _context = context;
        }

        public IList<Club> Club { get;set; }

        public async Task OnGetAsync()
        {
            Club = await _context.Club.ToListAsync();
        }
    }
}
