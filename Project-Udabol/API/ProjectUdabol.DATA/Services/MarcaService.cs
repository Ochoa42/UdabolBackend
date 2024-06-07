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
    public class MarcaService
    {
        private readonly UdabolDbContext _dbContext;

        public MarcaService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Marca>> GetMarcas()
        {
            return await _dbContext.Marcas.ToListAsync();
        }
        public async Task<Marca>GetMarcaId(int id)
        {
            return await _dbContext.Marcas.FindAsync(id);
        }
        public async Task<Marca> CreateMarca(Marca marca)
        {
            _dbContext.Marcas.Add(marca);
            await _dbContext.SaveChangesAsync();
            return marca;
        }
        public async Task<Marca?> UpdateMarca(Marca marca)
        {
            var existingMarca = await _dbContext.Marcas.FindAsync(marca.Id);
            if (existingMarca == null)
                return null;
            if(!existingMarca.Id.Equals(marca.Id))
                return null;
            if(!string.IsNullOrEmpty(marca.Name))
                existingMarca.Name = marca.Name;
            await _dbContext.SaveChangesAsync();
            return existingMarca;
        }

        public async Task<bool> DeleteMarcaById(int id)
        {
            var marca = await _dbContext.Marcas.FindAsync(id);
            if (marca == null) return false;
            _dbContext.Marcas.Remove(marca);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
