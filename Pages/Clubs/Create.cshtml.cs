#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesSoccer.Data;
using RazorPagesSoccer.Models;

namespace RazorPagesSoccer.Pages.Clubs
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesSoccer.Data.RazorPagesSoccerContext _context;

        public CreateModel(RazorPagesSoccer.Data.RazorPagesSoccerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Club Club { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Club.Add(Club);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
