using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appli_Web.Data;
using Appli_Web.Models;

namespace Appli_Web.Pages.Personne
{
    public class DetailsModel : PageModel
    {
        private readonly Appli_Web.Data.Appli_WebContext _context;

        public DetailsModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

      public Models.Personne Personne { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personne == null)
            {
                return NotFound();
            }

            var personne = await _context.Personne.FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }
            else 
            {
                Personne = personne;
            }
            return Page();
        }
    }
}
