using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALMACEN.Models;
using ALMACEN.Models.DTOs;
using ALMACEN.Repository;
using AutoMapper;

namespace ALMACEN.Controllers
{
    public class ProductoesController : Controller
    {
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IMapper _mapper;

        public ProductoesController(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _productoRepositorio = productoRepositorio;
            _mapper = mapper;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var productosDto = await _productoRepositorio.GetProductos();
            return View(productosDto);
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoDto = await _productoRepositorio.GetProducto(id.Value);
            if (productoDto == null)
            {
                return NotFound();
            }

            return View(productoDto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoDto productoDto)
        {
            if (ModelState.IsValid)
            {
                await _productoRepositorio.CrearOActualizar(productoDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productoDto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoDto = await _productoRepositorio.GetProducto(id.Value);
            if (productoDto == null)
            {
                return NotFound();
            }

            return View(productoDto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoDto productoDto)
        {
            if (id != productoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoRepositorio.CrearOActualizar(productoDto, id);
                return RedirectToAction(nameof(Index));
            }

            return View(productoDto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoDto = await _productoRepositorio.GetProducto(id.Value);
            if (productoDto == null)
            {
                return NotFound();
            }

            return View(productoDto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await _productoRepositorio.EliminarProducto(id);
            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
