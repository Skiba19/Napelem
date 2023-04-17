using Microsoft.EntityFrameworkCore;
using Napelem_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napelem_API.Data
{
    public class NapelemContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Log> Log { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Storage> Storages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Napelem;Trusted_Connection=True;");
        }
    }
}
