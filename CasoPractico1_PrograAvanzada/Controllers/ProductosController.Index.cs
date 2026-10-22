
using CasoPractico1_PrograAvanzada.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPractico1_PrograAvanzada.Controllers;

public partial class ProductosController
{
    public async Task<IActionResult> Index(
        string? filtro,
        UnidadMedida? unidad)
    {
        var productos = await _servicio.ListarAsync(filtro, unidad);

        ViewBag.Filtro = filtro;
        ViewBag.Unidad = unidad;

        return View(productos);
    }
}
