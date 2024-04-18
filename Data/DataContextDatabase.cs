using Microsoft.EntityFrameworkCore;
using SOSPets.Data.Mapping;
using SOSPets.Domain.Models;

namespace SOSPets.Data
{
    public class DataContextDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=crocheart.com.br;database=croch859_sospets;user=croch859_sospets;password=q1w2e3r4!@#");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());
        }

    }
}
