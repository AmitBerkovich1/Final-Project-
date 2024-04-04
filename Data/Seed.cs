using System.Diagnostics;
using System.Net;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.roles.Any())
                {
                    context.roles.AddRange(new List<Role>()
                    {
                        new Role()
                        {
                            title = "Junior",
                            jobDescription = "Just started working",
                            maxHours = 30,
                         },
                        new Role()
                        {
                            title = "Senior",
                            jobDescription = "Working for a while",
                            maxHours = 40,
                        },
                        new Role()
                        {
                            title = "Manager",
                            jobDescription = "Working for a long time",
                            maxHours = 60,
                        },
                    });
                    context.SaveChanges();
                }
                //Races
                if (!context.lineOfBusiness.Any())
                {
                    context.lineOfBusiness.AddRange(new List<LineOfBusiness>()
                    {
                        new LineOfBusiness()
                        {
                            title = "Water"
                        },
                        new LineOfBusiness()
                        {
                            title = "Metal"
                        }
                    }); 
                    context.SaveChanges();
                }
            }
        }
    }
}
