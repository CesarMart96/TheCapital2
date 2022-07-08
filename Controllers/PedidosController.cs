using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheCapitalBurguer.Models;

namespace TheCapitalBurguer.Controllers
{
    public class PedidosController : Controller
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Dirección,Telefono,Productos")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Dirección,Telefono,Productos")] Pedido pedido)
        {
            if (id != pedido.Nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Nombre))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(string id)
        {
            return _context.Pedidos.Any(e => e.Nombre == id);
        }
    }
}
