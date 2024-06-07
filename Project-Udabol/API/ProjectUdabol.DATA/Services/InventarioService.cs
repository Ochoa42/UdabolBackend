using Microsoft.EntityFrameworkCore;
using ProjectUdabol.DATA.Context;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DATA.Services
{
    public class InventarioService
    {
        private readonly UdabolDbContext _dbContext;

        public InventarioService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Inventario>> GetInventarios()
        {
            return await _dbContext.Inventarios.ToListAsync();
        }
        public async Task<Inventario> GetInventarioById(int id)
        {
            return await _dbContext.Inventarios.FindAsync(id);
        }

        public async Task<Inventario> CreateInventario(Inventario inventario)
        {
            _dbContext.Inventarios.Add(inventario);
            await _dbContext.SaveChangesAsync();
            return inventario;
        }

        public async Task<Inventario?> UpdateInventario(Inventario inventario)
        {
            var existingInventario = await _dbContext.Inventarios.FindAsync(inventario.Id);
            if (existingInventario == null)
                return null;

            existingInventario.capacidad = inventario.capacidad;
            existingInventario.fecha_ingreso = inventario.fecha_ingreso;

            await _dbContext.SaveChangesAsync();
            return existingInventario;
        }

        public async Task<bool> DeleteInventarioById(int id)
        {
            var inventario = await _dbContext.Inventarios.FindAsync(id);
            if (inventario == null) return false;

            _dbContext.Inventarios.Remove(inventario);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
