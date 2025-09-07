using BackendTrainingEst.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTrainingEst.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

    }
}
