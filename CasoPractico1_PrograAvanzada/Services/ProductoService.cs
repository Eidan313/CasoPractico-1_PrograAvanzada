using Microsoft.EntityFrameworkCore;
using CasoPractico1_PrograAvanzada.Data;
using CasoPractico1_PrograAvanzada.Models;
using CasoPractico1_PrograAvanzada.Services.Interfaces;
namespace CasoPractico1_PrograAvanzada.Services;
public class ProductoService : IProductoService
{
 private readonly ApplicationDbContext _db;
 public ProductoService(ApplicationDbContext db) => _db=db;
 // filtro busca por nombre o categoría (extensión opcional del enunciado).
 public Task<List<Producto>> ListarAsync(string? filtro,TipoVenta? tipoVenta)
 {
  var q=_db.Productos.AsNoTracking().AsQueryable();
  if(!string.IsNullOrWhiteSpace(filtro)) q=q.Where(x=>x.Nombre.Contains(filtro)||x.Categoria.Contains(filtro));
  if(tipoVenta.HasValue) q=q.Where(x=>x.TipoVenta==tipoVenta.Value);
  return q.OrderBy(x=>x.Nombre).ThenBy(x=>x.Id).ToListAsync();
 }
 public Task<Producto?> ObtenerAsync(int id)=>_db.Productos.FirstOrDefaultAsync(x=>x.Id==id);
 public Task<bool> ExisteCodigoAsync(string codigo,int idExcluir=0)=>_db.Productos.AnyAsync(x=>x.Codigo==codigo&&x.Id!=idExcluir);
 public async Task CrearAsync(Producto producto){_db.Productos.Add(producto);await _db.SaveChangesAsync();}
 public async Task ActualizarAsync(Producto producto){_db.Productos.Update(producto);await _db.SaveChangesAsync();}
 public async Task<bool> EliminarAsync(int id)
 {
  var producto=await _db.Productos.FindAsync(id);
  if(producto==null)return false;
  _db.Productos.Remove(producto);await _db.SaveChangesAsync();return true;
 }
}
