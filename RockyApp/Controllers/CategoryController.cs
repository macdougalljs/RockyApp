using Microsoft.AspNetCore.Mvc;
using RockyApp.Data;

namespace RockyApp.Controllers
{
    public class CategoryController : Controller
    {
        
        // the addDbContext was already added in Startup.Cs, so we create a Constructor

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)  // this generates an INSTANCE of the DbContext from the DI
        {
        _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
