using Microsoft.AspNetCore.Mvc;
using OrdemServicoApp.Data;
using OrdemServicoApp.Models;

namespace OrdemServicoApp.Controllers
{
    public class OrdemServicosController : Controller
    {
        private readonly IOrdemServicoRepository _repo;

        public OrdemServicosController(IOrdemServicoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string? q)
        {
            var list = _repo.Search(q);
            ViewBag.Query = q;
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View(new OrdemServico { DataEntrada = DateTime.Now, Status = StatusOrdem.Aberta });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrdemServico model)
        {
            if (!ModelState.IsValid) return View(model);
            _repo.Add(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrdemServico model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            _repo.Update(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _repo.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
