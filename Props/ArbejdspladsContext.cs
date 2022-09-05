using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace arbejdsplads.Props;

    public class ArbejdspladsContext: DbContext
    {
        public DbSet<Medarbejder>? medarbejder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-VGEMJ21E\\SQLEXPRESS;database=arbejdsplads;trusted_connection=true;");
        }

    }

  

