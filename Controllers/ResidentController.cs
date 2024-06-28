using Fiap.coleta.Data;
using Fiap.coleta.Data.Repository;
using Fiap.coleta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.coleta.Controllers
{
    public class ResidentController : Controller
    {
        private readonly IResidentService _service;
        public ResidentController(IResidentService service) {
            _service = service;
        }
        public IActionResult Index([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var residents = _service.findAll(page, limit);
            ViewBag.PageNumber = page;
            ViewBag.PageSize = limit;
            ViewBag.TotalItems = _service.Count();
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
            try {
                _service.Add(resident);

                TempData["message"] = "Morador " + resident.name + " cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            } catch(Exception e) {
                TempData["error"] = "Algo deu errado ao cadastrar o morador";
                return RedirectToAction(nameof(Index));
            }
        } 

        [HttpGet]
        public IActionResult Update(int id)
        {
            var residents = _service.findAll();
            var resident = residents.Where(r => r.id == id).FirstOrDefault();

            return View(resident);
        }

        [HttpPost]
        public IActionResult Update(ResidentModel resident)
        {
            try {
                _service.Update(resident);

                TempData["message"] = "Morador " + resident.name + " atualizado com sucesso";
                return RedirectToAction(nameof(Index));

            } catch(Exception e) {
                TempData["error"] = "Algo deu errado ao atualizar o morador";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            try{
                var deletedResident =_service.Remove(id);

                TempData["message"] = "Morador " + deletedResident.name + " deletado com sucesso";
                return RedirectToAction(nameof(Index));
            } catch(Exception e) {
                TempData["error"] = "Algo deu errado ao deletar o morador";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var resident = _service.findById(id);
            return View(resident);
        }
    }
}
