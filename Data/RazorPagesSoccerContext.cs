#nullable disable
using Microsoft.EntityFrameworkCore;
using RazorPagesSoccer.Models;

namespace RazorPagesSoccer.Data
{
    public class RazorPagesSoccerContext : DbContext
    {
        public RazorPagesSoccerContext (DbContextOptions<RazorPagesSoccerContext> options)
            : base(options)
        {
        }

        public DbSet<Club> Club { get; set; }
    }
}
