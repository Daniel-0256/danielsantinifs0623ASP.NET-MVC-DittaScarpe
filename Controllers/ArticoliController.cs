using DittaScarpe.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using static DittaScarpe.Models.Articolo;

namespace DittaScarpe.Controllers
{
    public class ArticoliController : Controller
    {
        private readonly List<Articolo> _listaArticoli = new List<Articolo>(); // Simulazione di un repository

        // GET: Articoli
        public IActionResult Index()
        {
            return View(_listaArticoli);
        }

        // GET: Articoli/Dettaglio/5
        public IActionResult Dettagli(int id)
        {
            var articolo = _listaArticoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
                return NotFound();

            return View(articolo);
        }

        // GET: Articoli/Nuovo
        public IActionResult Crea()
        {
            return View();
        }

        // POST: Articoli/Nuovo
        [HttpPost]
        public IActionResult Crea(Articolo articolo)
        {
            if (!ModelState.IsValid)
                return View(articolo);

            articolo.Id = _listaArticoli.Count + 1; // Simulazione di generazione ID
            _listaArticoli.Add(articolo); // Simulazione di aggiunta all'elenco

            return RedirectToAction("Index");
        }

        // GET: Articoli/Modifica/5
        public IActionResult Modifica(int id)
        {
            var articolo = _listaArticoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
                return NotFound();

            return View(articolo);
        }

        // POST: Articoli/Modifica/5
        [HttpPost]
        public IActionResult Modifica(Articolo articolo)
        {
            if (!ModelState.IsValid)
                return View(articolo);

            var articoloEsistente = _listaArticoli.FirstOrDefault(a => a.Id == articolo.Id);
            if (articoloEsistente == null)
                return NotFound();

            articoloEsistente.Nome = articolo.Nome;
            articoloEsistente.Prezzo = articolo.Prezzo;
            articoloEsistente.Descrizione = articolo.Descrizione;
            articoloEsistente.ImmagineCopertina = articolo.ImmagineCopertina;
            articoloEsistente.ImmagineAggiuntiva1 = articolo.ImmagineAggiuntiva1;
            articoloEsistente.ImmagineAggiuntiva2 = articolo.ImmagineAggiuntiva2;

            return RedirectToAction("Index");
        }

        // GET: Articoli/Elimina/5
        public IActionResult Elimina(int id)
        {
            var articolo = _listaArticoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
                return NotFound();

            return View(articolo);
        }

        // POST: Articoli/Elimina/5
        [HttpPost, ActionName("Elimina")]
        public IActionResult EliminaConfermato(int id)
        {
            var articolo = _listaArticoli.FirstOrDefault(a => a.Id == id);
            if (articolo == null)
                return NotFound();

            _listaArticoli.Remove(articolo); // Simulazione di rimozione dall'elenco

            return RedirectToAction("Index");
        }
    }
}
