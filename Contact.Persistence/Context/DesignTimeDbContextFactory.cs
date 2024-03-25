using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Contact.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContactDbContext>
    {
        public ContactDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ContactDbContext>();
            var connectionString = "User ID=postgres;Server=localhost;Port=5432;Database=testDb;Integrated Security=true;Pooling=true;";
            builder.UseNpgsql(connectionString);
            return new ContactDbContext(builder.Options);
        }
    }
}
