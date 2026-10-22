using CasoPractico1_PrograAvanzada.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPractico1_PrograAvanzada.Controllers;

// Parte de Esteban: consultar el detalle de un producto
public partial class ProductosController
{
    // GET: Productos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Producto? producto = await _servicio.ObtenerAsync(id.Value);
        if (producto == null)
        {
            TempData["Error"] = "El producto que busca no existe.";
            return RedirectToAction("Index");
        }

        return View(producto);
    }
}
