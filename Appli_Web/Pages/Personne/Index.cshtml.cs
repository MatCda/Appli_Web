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

        public IndexModel(Appli_Web.Data.Appli_WebContext context)
        {
            _context = context;
        }

        public IList<Models.Personne> Perosnne { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personne != null)
            {
                Perosnne = await _context.Personne.ToListAsync();
            }
        }
    }
}
