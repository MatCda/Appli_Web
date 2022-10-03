using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Appli_Web.Data;
using Appli_Web.Models;

namespace Appli_Web.Pages.Personne
{
    public class CreateModel : PageModel
    {
        private readonly Appli_Web.Data.Appli_WebContext _context;

        public CreateModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Personne Personne { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Personne.Add(Personne);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
