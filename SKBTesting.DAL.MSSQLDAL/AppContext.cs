using Microsoft.EntityFrameworkCore;
using SKBTesting.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKBTesting.DAL.MSSQLDAL
{
    public class AppContext: DbContext
    {
        public DbSet<ItemDTO> Items { get; set; }
        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["DBConnectionString"]);
        }
    }
}
