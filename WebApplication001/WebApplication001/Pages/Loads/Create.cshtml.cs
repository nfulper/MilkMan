using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication001.Models;

namespace WebApplication001.Pages.Loads
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication001.Models.LoadContext _context;

        public CreateModel(WebApplication001.Models.LoadContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Load Load { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Load.Add(Load);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}