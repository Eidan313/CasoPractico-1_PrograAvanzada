using CasoPractico1_PrograAvanzada.Models;
namespace CasoPractico1_PrograAvanzada.Services.Interfaces;
public interface IProductoService
{
 Task<List<Producto>> ListarAsync(string? filtro,TipoVenta? tipoVenta);
 Task<Producto?> ObtenerAsync(int id);
 Task<bool> ExisteCodigoAsync(string codigo,int idExcluir=0);
 Task CrearAsync(Producto producto);
 Task ActualizarAsync(Producto producto);
 Task<bool> EliminarAsync(int id);
}
