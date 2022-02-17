using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Species
{
    public class IndexModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public IndexModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        public IList<Specie> Specie { get;set; }

        public async Task OnGetAsync()
        {
            Specie = await _context.Specie.ToListAsync();
        }
    }
}
