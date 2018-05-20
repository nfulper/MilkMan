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
    public class IndexModel : PageModel
    {
        private readonly WebApplication001.Models.LoadContext _context;

        public IndexModel(WebApplication001.Models.LoadContext context)
        {
            _context = context;
        }

        public IList<Load> Load { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            var loads = from l in _context.Load
                         select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                loads = loads.Where(s => s.FarmName.Contains(searchString));
            }

            Load = await loads.ToListAsync();
        }
    }
}

    
