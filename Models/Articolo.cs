using System.ComponentModel.DataAnnotations;

namespace DittaScarpe.Models
{
    public class Articolo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Prezzo { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Display(Name = "Immagine di copertina")]
        [Url]
        public string ImmagineCopertina { get; set; }

        [Display(Name = "Immagine aggiuntiva 1")]
        [Url]
        public string ImmagineAggiuntiva1 { get; set; }

        [Display(Name = "Immagine aggiuntiva 2")]
        [Url]
        public string ImmagineAggiuntiva2 { get; set; }
    }
}
