using Fiap.coleta.Data;
using Fiap.coleta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.coleta.Controllers
{
    public class ResidentController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public ResidentController(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            var residents = _databaseContext.Residents.Include(r => r.Address).ToList();
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
            _databaseContext.Residents.Add(resident);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 

        [HttpGet]
        public IActionResult Update(int id)
        {
            var residents = _databaseContext.Residents.Include(r => r.Address).ToList();
            var resident = residents.Where(r => r.id == id).FirstOrDefault();

            return View(resident);
        }

        [HttpPost]
        public IActionResult Update(ResidentModel resident)
        {
            _databaseContext.Residents.Update(resident);
            _databaseContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var resident = _databaseContext.Residents.Find(id);

            if(resident != null) {
                _databaseContext.Residents.Remove(resident);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var residents = _databaseContext.Residents.Include(r => r.Address).ToList();
            var resident = residents.Where(r => r.id == id).FirstOrDefault();
            return View(resident);
        }
    }
}
