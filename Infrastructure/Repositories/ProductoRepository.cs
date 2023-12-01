using FLOWFIT;
using flowfitapi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowfitapi.Infrastructure.Repositories
{
    public class ProductoRepository
    {
        private readonly flowfitapiDbContext _context;

        public ProductoRepository(flowfitapiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            return await _context.Productos.FirstOrDefaultAsync(producto => producto.id_producto == id)
                ?? new Producto
                {
                    id_producto = -1,
                    Nombre = string.Empty,
                    Descripcion = string.Empty,
                    Precio = 0.0m,
                    Imagen = string.Empty,
                    id_proveedor = 0 // Cambia esto según tus necesidades.
                };
        }

        public async Task AddAsync(Producto producto)
        {
            // No es necesario generar un ID único aquí, ya que el contexto de datos se encargará de eso
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto updatedProducto)
        {
            var existingProducto = await _context.Productos.FirstOrDefaultAsync(producto => producto.id_producto == updatedProducto.id_producto);

            if (existingProducto != null)
            {
                existingProducto.Nombre = updatedProducto.Nombre;
                existingProducto.Descripcion = updatedProducto.Descripcion;
                existingProducto.Precio = updatedProducto.Precio;
                existingProducto.Imagen = updatedProducto.Imagen;
                existingProducto.id_proveedor = updatedProducto.id_proveedor; // Ajusta esto según tu modelo de datos.

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var productoToDelete = await _context.Productos.FirstOrDefaultAsync(producto => producto.id_producto == id);

            if (productoToDelete != null)
            {
                _context.Productos.Remove(productoToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
