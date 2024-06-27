using Fiap.coleta.Data;
using Fiap.coleta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.coleta.Controllers
{
    public class ResidentController : Controller
    {
        public IList<ResidentModel> residents { get; set; }

        private readonly DatabaseContext _databaseContext;
        public ResidentController(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
            residents = _databaseContext.Residents.ToList();
        }
        public IActionResult Index()
        {
            return View(residents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ResidentModel resident)
        {
            _databaseContext.Addresses.Add(new AddressModel("58404333", "rua teste", "bairro teste", 12, "sp", "sp"));
            _databaseContext.Residents.Add(resident);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 
    }
}
