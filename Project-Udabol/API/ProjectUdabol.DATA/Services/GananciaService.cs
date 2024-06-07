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
    public class GananciaService
    {
        private readonly UdabolDbContext _dbContext;

        public GananciaService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ganancia>> GetGanancias()
        {
            return await _dbContext.Ganancias.ToListAsync();
        }

        public async Task<Ganancia> GetGananciaById(int id)
        {
            return await _dbContext.Ganancias.FindAsync(id);
        }

        public async Task<Ganancia> CreateGanancia(Ganancia ganancia)
        {
            _dbContext.Ganancias.Add(ganancia);
            await _dbContext.SaveChangesAsync();
            return ganancia;
        }

        public async Task<Ganancia?> UpdateGanancia(Ganancia ganancia)
        {
            var existingGanancia = await _dbContext.Ganancias.FindAsync(ganancia.Id);
            if (existingGanancia == null)
                return null;

            existingGanancia.fecha_Ganancia = ganancia.fecha_Ganancia;
            existingGanancia.descripcion = ganancia.descripcion;
            existingGanancia.saldo = ganancia.saldo;

            await _dbContext.SaveChangesAsync();
            return existingGanancia;
        }

        public async Task<bool> DeleteGananciaById(int id)
        {
            var ganancia = await _dbContext.Ganancias.FindAsync(id);
            if (ganancia == null) return false;

            _dbContext.Ganancias.Remove(ganancia);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
