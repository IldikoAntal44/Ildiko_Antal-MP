using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public DetailsModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        public Animale Animale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animale = await _context.Animale
                .Include(a => a.Adapost)
                .Include(a => a.Specie).FirstOrDefaultAsync(m => m.ID == id);

            if (Animale == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
