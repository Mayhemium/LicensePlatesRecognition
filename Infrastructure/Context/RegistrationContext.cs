using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<RegistrationPlate> RegistrationPlate { get; set; }
    }
}