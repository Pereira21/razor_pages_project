using Microsoft.EntityFrameworkCore;
using RazorPagesSoccer.Data;

namespace RazorPagesSoccer.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesSoccerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesSoccerContext>>()))
            {
                if (context == null || context.Club == null)
                {
                    throw new ArgumentNullException("Null RazorPagesSoccerContext");
                }

                // Look for any movies.
                if (context.Club.Any())
                {
                    return;   // DB has been seeded
                }

                context.Club.AddRange(
                    new Club
                    {
                        Name = "Fluminense",
                        Founding = new DateTime(1902, 02, 27)
                    },

                    new Club
                    {
                        Name = "Flamengo",
                        Founding = new DateTime(1908, 10, 11)
                    },

                    new Club
                    {
                        Name = "Botafogo",
                        Founding = new DateTime(1904, 08,24)
                    },

                    new Club
                    {
                        Name = "Vasco",
                        Founding = new DateTime(1907, 04, 17)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
