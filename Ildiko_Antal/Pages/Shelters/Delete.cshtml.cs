using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Shelters
{
    public class DeleteModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public DeleteModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Adapost Adapost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Adapost = await _context.Adapost.FirstOrDefaultAsync(m => m.ID == id);

            if (Adapost == null)
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

            Adapost = await _context.Adapost.FindAsync(id);

            if (Adapost != null)
            {
                _context.Adapost.Remove(Adapost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
