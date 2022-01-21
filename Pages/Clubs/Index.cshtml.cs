#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<Club> Club { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList States { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ClubState { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> stateQuery = from m in _context.Club
                                            orderby m.State
                                            select m.State;

            var clubs = from m in _context.Club
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                clubs = clubs.Where(s => s.State.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ClubState))
            {
                clubs = clubs.Where(x => x.State == ClubState);
            }

            States = new SelectList(await stateQuery.Distinct().ToListAsync());
            Club = await clubs.ToListAsync();
        }
    }
}
