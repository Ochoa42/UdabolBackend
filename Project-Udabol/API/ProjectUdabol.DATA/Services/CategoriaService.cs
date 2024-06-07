using Microsoft.EntityFrameworkCore;
using ProjectUdabol.DATA.Context;
using ProjectUdabol.DOMAIN.Models.Cis;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DATA.Services
{
    public class CategoriaService
    {
        private readonly UdabolDbContext _dbContext;

        public CategoriaService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        public async Task<Categoria> GetCategoriaId(int id)
        {
            return await _dbContext.Categorias.FindAsync(id);
        }
        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria?> UpdateCategoria(Categoria categoria)
        {
            var existingCategori = await _dbContext.Categorias.FindAsync(categoria.id);
            
            if (existingCategori == null)
                return null;
            if(!existingCategori.id.Equals(categoria.id))
                return null;
            if(!string.IsNullOrEmpty(categoria.Name))
                existingCategori.Name = categoria.Name;
            
            await _dbContext.SaveChangesAsync();
            return existingCategori;

        } 

        public async Task<bool> DeleteCategoriById(int id)
        {
            var categori = await _dbContext.Categorias.FindAsync(id);
            if(categori == null)
                return false;
            _dbContext.Categorias.Remove(categori);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;

        }
    }
}
