using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication001.Models;

namespace WebApplication001.Pages.Loads
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication001.Models.LoadContext _context;

        public DeleteModel(WebApplication001.Models.LoadContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Load Load { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Load = await _context.Load.SingleOrDefaultAsync(m => m.ID == id);

            if (Load == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Load = await _context.Load.FindAsync(id);

            if (Load != null)
            {
                _context.Load.Remove(Load);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
