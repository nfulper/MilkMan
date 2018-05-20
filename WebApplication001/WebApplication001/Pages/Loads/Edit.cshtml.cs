using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication001.Models;

namespace WebApplication001.Pages.Loads
{
    public class EditModel : PageModel
    {
        private readonly WebApplication001.Models.LoadContext _context;

        public EditModel(WebApplication001.Models.LoadContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(Load.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoadExists(int id)
        {
            return _context.Load.Any(e => e.ID == id);
        }
    }
}
