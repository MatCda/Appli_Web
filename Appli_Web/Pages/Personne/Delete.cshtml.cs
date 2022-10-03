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
    public class DeleteModel : PageModel
    {
        private readonly Appli_Web.Data.Appli_WebContext _context;

        public DeleteModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personne == null)
            {
                return NotFound();
            }
            var personne = await _context.Personne.FindAsync(id);

            if (personne != null)
            {
                Personne = personne;
                _context.Personne.Remove(Personne);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
