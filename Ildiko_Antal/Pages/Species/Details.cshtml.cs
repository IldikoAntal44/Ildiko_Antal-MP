﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Pages.Species
{
    public class DetailsModel : PageModel
    {
        private readonly Ildiko_Antal.Models.Ildiko_AntalContext _context;

        public DetailsModel(Ildiko_Antal.Models.Ildiko_AntalContext context)
        {
            _context = context;
        }

        public Specie Specie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specie = await _context.Specie.FirstOrDefaultAsync(m => m.ID == id);

            if (Specie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
