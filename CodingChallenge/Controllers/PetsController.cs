using CodingChallenge.Models;
using System.Web.Mvc;

namespace CodingChallenge.Controllers
{
    public class PetsController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            var model = People.GetOrderedPetsWithOwnersGender();
            return View(model);
        }
    }
}