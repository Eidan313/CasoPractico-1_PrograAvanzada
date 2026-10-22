using Microsoft.AspNetCore.Mvc;
using CasoPractico1_PrograAvanzada.Services.Interfaces;
namespace CasoPractico1_PrograAvanzada.Controllers;
// Clase parcial: cada integrante agrega sus acciones en su propio archivo
// (ProductosController.Index.cs, .Create.cs, .Edit.cs, .Delete.cs) para no editar el mismo .cs.
public partial class ProductosController : Controller
{
 private readonly IProductoService _servicio;
 public ProductosController(IProductoService servicio)=>_servicio=servicio;
}
