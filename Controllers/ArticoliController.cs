using DittaScarpe.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static DittaScarpe.Models.Articolo;

namespace DittaScarpe.Controllers
{
    public class ArticoliController : Controller
    {
        private static List<Articolo> _articoli = new List<Articolo>();

        public IActionResult Index()
        {
            return View(_articoli);
        }

        public IActionResult Dettagli(int id)
        {
            var articolo = _articoli.FirstOrDefault(a => a.Id == id);
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
        public ActionResult SalvaArticolo(Articolo nuovoArticolo)
        {
            if (ModelState.IsValid)
            {
                _articoli.Add(nuovoArticolo);

                TempData["Messaggio"] = "L'articolo è stato salvato con successo!";
                return RedirectToAction("Index");
            }

            return View("Crea", nuovoArticolo);
        }

        public IActionResult Modifica(int id)
        {
            var articolo = _articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        [HttpPost]
        public IActionResult Modifica(Articolo articoloModificato)
        {
            if (ModelState.IsValid)
            {
                var articolo = _articoli.FirstOrDefault(a => a.Id == articoloModificato.Id);
                if (articolo == null)
                {
                    return NotFound();
                }
                articolo.Nome = articoloModificato.Nome;
                articolo.Prezzo = articoloModificato.Prezzo;
                articolo.Descrizione = articoloModificato.Descrizione;
                articolo.ImmagineCopertina = articoloModificato.ImmagineCopertina;
                articolo.ImmagineAggiuntiva1 = articoloModificato.ImmagineAggiuntiva1;
                articolo.ImmagineAggiuntiva2 = articoloModificato.ImmagineAggiuntiva2;

                TempData["Messaggio"] = "L'articolo è stato modificato con successo!";
                return RedirectToAction("Index");
            }
            return View(articoloModificato);
        }

        public IActionResult Elimina(int id)
        {
            var articolo = _articoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }


        [HttpPost]
        public IActionResult Elimina(Articolo articoloDaEliminare)
        {
            var articolo = _articoli.FirstOrDefault(a => a.Id == articoloDaEliminare.Id);
            if (articolo == null)
            {
                return NotFound();
            }
            _articoli.Remove(articolo);
            TempData["Messaggio"] = "L'articolo è stato eliminato con successo!";
            return RedirectToAction("Index");
        }
    }
}
