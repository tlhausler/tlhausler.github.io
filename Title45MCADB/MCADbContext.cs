using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Title45MCADB.Entities;

namespace Title45MCADB
{
    public class MCADbContext : DbContext
    {
        // Establishing DbSet of Title45 items and naming of table
        public DbSet<Title45> Title45Items { get; set; }
        public MCADbContext()
        {

        }

        // connection string for connection to SQL databse
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Title45MCADB;Integrated Security=True");
        }
    }
}
