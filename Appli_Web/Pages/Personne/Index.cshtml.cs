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
    public class IndexModel : PageModel
    {
        private readonly Appli_Web.Data.Appli_WebContext _context;

        public string NameSort { get; set; }

        public IndexModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

        public IList<Models.Personne> Personne { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IQueryable<Models.Personne> personne = from s in _context.Personne orderby s.Name
                                             select s;

            switch (sortOrder)
            {
                case "name_desc":
                    personne = personne.OrderByDescending(s => s.Name);
                    break;

                default:
                    personne = personne.OrderBy(s => s.Name);
                    break;
            }

            if (_context.Personne != null)
            {
                Personne = await personne.AsNoTracking().ToListAsync();
            }
        }
    }
}
