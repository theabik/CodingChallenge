using CodingChallenge.Models;
using System.Web.Mvc;

namespace CodingChallenge.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            var model = People.GetOrderedPeopleWithPets();
            return View(model);
        }
    }
}