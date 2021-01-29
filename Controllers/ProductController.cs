using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDtest.Models;
using Microsoft.AspNetCore.Identity;

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

        // GET: Product/Create
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

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Html,Created")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Created = System.DateTime.Now;
                product.User = User.Identity.Name ?? "Third party";

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

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: api/Products
        [HttpGet]
        [Route("api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = _context.Product.AsQueryable();
            return await products.ToListAsync();
        }

        // GET: api/Products/{id}
        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var products = await _context.Product.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }
    }
}
