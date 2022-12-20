using MVC_LAB.Context;

namespace MVC_LAB.Models.Person
{
    public class PersonModel
    {
        public PersonModel()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string City { get; set; }

    }
}
