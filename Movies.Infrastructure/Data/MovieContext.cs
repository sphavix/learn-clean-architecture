using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MovieContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MovieContext(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Movie> Movies { get; set; }
    }
}