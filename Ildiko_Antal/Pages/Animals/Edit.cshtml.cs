using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Animals
{
    public class EditModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public EditModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AdapostID"] = new SelectList(_context.Set<Adapost>(), "ID", "adresaadapost");
           ViewData["SpecieID"] = new SelectList(_context.Set<Specie>(), "ID", "denumirespecie");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Animale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimaleExists(Animale.ID))
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

        private bool AnimaleExists(int id)
        {
            return _context.Animale.Any(e => e.ID == id);
        }
    }
}
