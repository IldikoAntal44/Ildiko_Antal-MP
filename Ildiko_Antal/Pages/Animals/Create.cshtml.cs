using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Animals
{
    public class CreateModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public CreateModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AdapostID"] = new SelectList(_context.Set<Adapost>(), "ID", "adresaadapost");
        ViewData["SpecieID"] = new SelectList(_context.Set<Specie>(), "ID", "denumirespecie");
            return Page();
        }

        [BindProperty]
        public Animale Animale { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Animale.Add(Animale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}