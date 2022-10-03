using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Appli_Web.Models;

namespace Appli_Web.Data
{
    public class Appli_WebContext : DbContext
    {
        public Appli_WebContext (DbContextOptions<Appli_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Appli_Web.Models.Personne> Personne { get; set; } = default!;
    }
}
