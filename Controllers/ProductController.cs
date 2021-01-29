using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUDtest.Models;

namespace CRUDtest.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Product/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Product());
            }
            else
            {
                return View(_context.Product.Find(id));
            }
        }

        // POST: Product/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Html,Created")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Created = System.DateTime.Now;
                product.User = User.Identity.Name;

                if (product.Id == 0)
                {
                    _context.Add(product);

                }
                else
                {
                    _context.Update(product);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: api/Products
        [HttpGet("api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = _context.Product.AsQueryable();
            return await products.ToListAsync();
        }

        // GET: api/Products/{id}
        [HttpGet("api/products/{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var products = await _context.Product.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // POST: api/products
        [HttpPost("api/products")]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            product.Created = System.DateTime.Now;
            product.User = "api";
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }

        // PUT: api/Products/{id}
        [HttpPut("api/products/{id}")]
        public async Task<IActionResult> PutProducts(int id, Product product)
        {
            product.Created = System.DateTime.Now;
            product.User = "api";
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Product.Update(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("api/products/{id}")]
        public async Task<ActionResult<Product>> DeleteProducts(int id)
        {
            var products = await _context.Product.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Product.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
