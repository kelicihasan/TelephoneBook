using Contact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact.Persistence.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>()
            .HasOne(s => s.Person)
            .WithMany(g => g.ContactInfos)
            .HasForeignKey(s => s.PersonId);

        }
    }
}
