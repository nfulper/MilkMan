using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication001.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LoadContext(
                serviceProvider.GetRequiredService<DbContextOptions<LoadContext>>()))
            {
                // Look for any Load.
                if (context.Load.Any())
                {
                    return;   // DB has been seeded
                }

                context.Load.AddRange(
                    new Load
                    {
                        FarmName = "High Top Farm",
                        Pounds = 50122,
                        Time= DateTime.Parse("2017-3-20"),
                    },

                    new Load
                    {
                        FarmName = "River Bottom Farm",
                        Pounds = 48233,
                        Time = DateTime.Parse("2017-3-25"),
                    },

                    new Load
                    {
                        FarmName = "Mountain Valley Farm",
                        Pounds = 52327,
                        Time = DateTime.Parse("2018-1-12"),
                    },

                    new Load
                    {
                        FarmName = "Rocky Hill Farm",
                        Pounds = 53698,
                        Time = DateTime.Parse("2016-4-25"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
   
