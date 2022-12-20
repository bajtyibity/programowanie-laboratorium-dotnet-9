using Microsoft.EntityFrameworkCore;
using MVC_LAB.Context;
using MVC_LAB.Models.Person;

namespace MVC_LAB.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonContext(serviceProvider.GetRequiredService<DbContextOptions<PersonContext>>()))
            {
                if (context.Persons.Any())
                {
                    return;
                }
                context.Persons.AddRange(
                    new PersonModel()
                    {
                        Name = "Andrzej",
                        City = "Rzeszów",
                        Gender = GenderEnum.Male,
                        ID = 1
                    },
                    new PersonModel()
                    {
                        Name = "Katarzyna",
                        City = "Rzeszów",
                        Gender = GenderEnum.Female,
                        ID = 2
                    },
                    new PersonModel()
                    {
                        Name = "Julia",
                        City = "Kraków",
                        Gender = GenderEnum.Female,
                        ID = 3
                    },
                    new PersonModel()
                    {
                        Name = "Piotr",
                        City = "Warszawa",
                        Gender = GenderEnum.Male,
                        ID = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
