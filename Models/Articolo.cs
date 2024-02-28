using System.ComponentModel.DataAnnotations;

namespace DittaScarpe.Models
{
    public class Articolo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome dell'articolo è obbligatorio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il prezzo dell'articolo è obbligatorio.")]
        public decimal Prezzo { get; set; }

        [Required(ErrorMessage = "La descrizione dell'articolo è obbligatoria.")]
        public string Descrizione { get; set; }

        [Display(Name = "Immagine di copertina")]
        [Url(ErrorMessage = "Inserisci un URL valido per l'immagine di copertina.")]
        public string ImmagineCopertina { get; set; }

        [Display(Name = "Immagine aggiuntiva 1")]
        [Url(ErrorMessage = "Inserisci un URL valido per l'immagine aggiuntiva 1.")]
        public string ImmagineAggiuntiva1 { get; set; }

        [Display(Name = "Immagine aggiuntiva 2")]
        [Url(ErrorMessage = "Inserisci un URL valido per l'immagine aggiuntiva 2.")]
        public string ImmagineAggiuntiva2 { get; set; }
    }
}
