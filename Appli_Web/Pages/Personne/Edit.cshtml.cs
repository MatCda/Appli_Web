using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Appli_Web.Data;
using Appli_Web.Models;

namespace Appli_Web.Pages.Personne
{
    public class EditModel : PageModel
    {
        private readonly Appli_Web.Data.Appli_WebContext _context;
        public string Message { get; set; }

        public EditModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Personne Personne { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personne == null)
            {
                return NotFound();
            }

            var personne =  await _context.Personne.FirstOrDefaultAsync(m => m.Id == id);
            if (personne == null)
            {
                return NotFound();
            }
            Personne = personne;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Personne.Age = DateTime.Today.Year - Personne.Birthdate.Year;

            if (Personne.Age >= 150)
            {
                Message = "Age non crédible - Vérifier la date de naissance";
                return Page();
            }

            _context.Attach(Personne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerosnneExists(Personne.Id))
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

        private bool PerosnneExists(int id)
        {
          return _context.Personne.Any(e => e.Id == id);
        }
    }
}
