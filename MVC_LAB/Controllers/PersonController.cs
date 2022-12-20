using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_LAB.Models.Person;
using MVC_LAB.Services;

namespace MVC_LAB.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            var model = new PersonViewModel()
            {
                Persons = _personService.GetPersons()
            };
            return View(model);
        }

        public IActionResult NewPerson()
        {
            var model = new CreatePersonViewModel()
            {
                Gender = new List<SelectListItem>()
            };

            foreach (GenderEnum gender in (GenderEnum[])Enum.GetValues(typeof(GenderEnum)))
            {
                model.Gender.Add(new SelectListItem() { Text = gender.ToString(), Value = ((int)gender).ToString() });

            }
            return View(model);

        }

        public IActionResult CreateNewPerson(string name, string city, GenderEnum gender)
        {
            _personService.CreatePerson(name, city, gender);
            return RedirectToAction("Index");
        }

        public IActionResult Editperson(int id)
        {
            var person = _personService.GetPerson(id);
            var model = new EditPersonViewModel()
            {
                Gender = new List<SelectListItem>()
            };

            foreach (GenderEnum gender in (GenderEnum[])Enum.GetValues(typeof(GenderEnum)))
            {
                model.Gender.Add(new SelectListItem() { Text = gender.ToString(), Value = ((int)gender).ToString(), Selected = person.Gender == gender });

            }
            return View(model);
        }

        public IActionResult EditPersonDetails(long id, string name, string city, GenderEnum gender)
        {
            _personService.EditPerson(id, name, city, gender);
            return RedirectToAction("Index");

        }
    } 
}
