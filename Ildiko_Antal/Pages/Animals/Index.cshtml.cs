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
    public class IndexModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public IndexModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        public IList<Animale> Animale { get;set; }

        public async Task OnGetAsync()
        {
            Animale = await _context.Animale
                .Include(a => a.Adapost)
                .Include(a => a.Specie).ToListAsync();
        }
    }
}
