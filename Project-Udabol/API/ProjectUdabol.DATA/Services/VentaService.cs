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
    public class VentaService
    {
        private readonly UdabolDbContext _dbContext;

        public VentaService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Venta>> GetVentas()
        {
            return await _dbContext.Ventas.ToListAsync();
        }

        public async Task<Venta> GetVentaById(int id)
        {
            return await _dbContext.Ventas.FindAsync(id);
        }

        public async Task<Venta> CreateVenta(Venta venta)
        {
            _dbContext.Ventas.Add(venta);
            await _dbContext.SaveChangesAsync();
            return venta;
        }

        public async Task<Venta?> UpdateVenta(Venta venta)
        {
            var existingVenta = await _dbContext.Ventas.FindAsync(venta.Id);
            if (existingVenta == null)
                return null;

            existingVenta.Total_Venta = venta.Total_Venta;

            await _dbContext.SaveChangesAsync();
            return existingVenta;
        }

        public async Task<bool> DeleteVentaById(int id)
        {
            var venta = await _dbContext.Ventas.FindAsync(id);
            if (venta == null) return false;

            _dbContext.Ventas.Remove(venta);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
