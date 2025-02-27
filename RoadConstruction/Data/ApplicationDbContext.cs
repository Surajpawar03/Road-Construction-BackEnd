using Microsoft.EntityFrameworkCore;
using RoadConstruction.Models;

namespace RoadConstruction.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ConstructionProject> ConstructionProjects { get; set; }
    }
}
