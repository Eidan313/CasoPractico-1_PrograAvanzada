using CasoPractico1_PrograAvanzada.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPractico1_PrograAvanzada.Controllers;

// Parte de Esteban: crear un producto (Create GET y POST)
public partial class ProductosController
{
    // GET: Productos/Create
    // Muestra el formulario vacío; Activo inicia en true (valor inicial del enunciado)
    public IActionResult Create()
    {
        return View(new Producto { Activo = true });
    }

    // POST: Productos/Create
    // Valida con Data Annotations (ModelState), revisa que el código no exista y guarda con EF
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Producto producto)
    {
        if (!string.IsNullOrWhiteSpace(producto.Codigo) && await _servicio.ExisteCodigoAsync(producto.Codigo))
        {
            ModelState.AddModelError(nameof(Producto.Codigo), "Ya existe un producto con ese código.");
        }

        // Si hay errores, se devuelve la misma vista con los datos digitados
        if (!ModelState.IsValid)
        {
            return View(producto);
        }

        try
        {
            await _servicio.CrearAsync(producto); // Add + SaveChangesAsync
            TempData["Exito"] = $"Producto \"{producto.Nombre}\" creado correctamente.";

            // El enunciado pide ver los datos del producto después de guardarlo
            return RedirectToAction("Details", new { id = producto.Id });
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "No se pudo guardar el producto. Intente de nuevo.");
            return View(producto);
        }
    }
}
