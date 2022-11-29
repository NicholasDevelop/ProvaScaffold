using ProvaScaffold.Repository.Models;

namespace ProvaScaffold.Controllers.Dto
{
    public class ProductResponse
    {
        public int TotElement { get; set; }
        public List<Product> Products { get; set; }
    }
}
