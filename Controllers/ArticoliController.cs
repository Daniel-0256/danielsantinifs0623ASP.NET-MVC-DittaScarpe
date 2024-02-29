using DittaScarpe.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static DittaScarpe.Models.Articolo;

namespace DittaScarpe.Controllers
{
    public class ArticoliController : Controller
    {
        private readonly DittaScarpeContext _context;

        public ArticoliController(DittaScarpeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var articoli = _context.Articoli.ToList();
            return View(articoli);
        }

        public IActionResult Dettagli(int id)
        {
            var articolo = _context.Articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        public IActionResult Crea()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvaArticolo(Articolo nuovoArticolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nuovoArticolo);
                await _context.SaveChangesAsync();

                TempData["Messaggio"] = "L'articolo è stato salvato con successo!";
                return RedirectToAction("Index");
            }

            return View("Crea", nuovoArticolo);
        }

        public IActionResult Modifica(int id)
        {
            var articolo = _context.Articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        [HttpPost]
        public async Task<IActionResult> Modifica(Articolo articoloModificato)
        {
            if (ModelState.IsValid)
            {
                _context.Update(articoloModificato);
                await _context.SaveChangesAsync();

                TempData["Messaggio"] = "L'articolo è stato modificato con successo!";
                return RedirectToAction("Index");
            }
            return View(articoloModificato);
        }

        public IActionResult Elimina(int id)
        {
            var articolo = _context.Articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }


        [HttpPost]
        public async Task<IActionResult> ConfermaElimina(int id)
        {
            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo == null)
            {
                return NotFound();
            }

            _context.Articoli.Remove(articolo);
            await _context.SaveChangesAsync();

            TempData["Messaggio"] = "L'articolo è stato eliminato con successo!";
            return RedirectToAction("Index");
        }
    }
}
