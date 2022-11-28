using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProvaScaffold.Controllers.Dto;
using ProvaScaffold.Repository;
using ProvaScaffold.Repository.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace ProvaScaffold.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AdventureDbContext _context;

        public HomeController(AdventureDbContext context)
        {
            _context = context;
        }

        [HttpGet("{search}")]
        public IActionResult GetByString(string? search)
        {
            IQueryable<Employee> employees = _context.Employees;

            if (search != null && search != "")
            {
                employees = employees.Where(e => e.JobTitle.Contains(search));
            }

            return Ok(employees.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product product = _context.Products.Where(p => p.ProductId == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Search(ProductRequest productRequest)
        {
            Product? product = _context.Products.Where(p => p.Name.Contains(productRequest) && p.ListPrice == productRequest.ListPrice);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
