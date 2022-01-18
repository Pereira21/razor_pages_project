#nullable disable
using Microsoft.EntityFrameworkCore;
using RazorPagesSoccer.Models;
using RazorPagesSoccer.Models.Mappings;
using System.Reflection;

namespace RazorPagesSoccer.Data
{
    public class RazorPagesSoccerContext : DbContext
    {
        public RazorPagesSoccerContext (DbContextOptions<RazorPagesSoccerContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Club { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
                .HaveMaxLength(255);

            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ClubMapping)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
