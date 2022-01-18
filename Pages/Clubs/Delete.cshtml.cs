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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesSoccer.Data.RazorPagesSoccerContext _context;

        public DeleteModel(RazorPagesSoccer.Data.RazorPagesSoccerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Club Club { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = await _context.Club.FirstOrDefaultAsync(m => m.Id == id);

            if (Club == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club = await _context.Club.FindAsync(id);

            if (Club != null)
            {
                _context.Club.Remove(Club);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
