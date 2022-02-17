using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Shelters
{
    public class EditModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public EditModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Adapost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdapostExists(Adapost.ID))
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

        private bool AdapostExists(int id)
        {
            return _context.Adapost.Any(e => e.ID == id);
        }
    }
}
