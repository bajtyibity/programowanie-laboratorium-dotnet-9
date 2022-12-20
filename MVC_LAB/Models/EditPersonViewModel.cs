using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_LAB.Models.Person
{
    public class EditPersonViewModel
    { 
        public string Name { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public string City { get; set; }
        public int ID { get; set; }
    }
}
