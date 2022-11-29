using System.ComponentModel.DataAnnotations;

namespace ProvaScaffold.Controllers.Dto
{
    public class ProductRequest
    {
        //[Required]
        //[MinLength(1, ErrorMessage = "Il nome deve avere almeno 1 carattere")]
        [StringLength(60, ErrorMessage = "Il nome del prodotto non può avere più di 60 caratteri")]
        public string Name { get; set; }
        
        public decimal minPrice { get; set; }

        //[Range(0, 5000, ErrorMessage = "Il prezzo massimo non può essere inferiore a 0 o maggiore di 5000")]
        public decimal maxPrice { get; set; }
        public int PageIndex { get; set; }
        public int ElementInPage { get; set; }
    }
}
