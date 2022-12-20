using Microsoft.EntityFrameworkCore;
using MVC_LAB.Models.Person;


namespace MVC_LAB.Context
{
    public class PersonContext : DbContext
    {

        public PersonContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
