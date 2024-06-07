using ProjectUdabol.DATA.Context;
using ProjectUdabol.DOMAIN.Models.Cis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectUdabol.DATA.Services
{
    public class UsuarioService
    {
        private readonly UdabolDbContext _dbContext;

        public UsuarioService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioId(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }
        public async Task<Usuario> CreateUser(Usuario user)
        {
            _dbContext.Usuarios.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Usuario?> UpdateUser(Usuario user)
        {
            var existingUser =  await _dbContext.Usuarios.FindAsync(user.Id);
            
            if (existingUser == null)
                return null;
            if (!existingUser.Id.Equals(user.Id))
                return null;
            if (!string.IsNullOrEmpty(user.FirstName))
                existingUser.FirstName = user.FirstName;
            if (!string.IsNullOrEmpty(user.LastName))
                existingUser.LastName = user.LastName;
            if (!string.IsNullOrEmpty(user.City))
                existingUser.City = user.City;
            if (!string.IsNullOrEmpty(user.Country))
                existingUser.Country = user.Country;
            if (!string.IsNullOrEmpty(user.Phone))
                existingUser.Phone = user.Phone;
            if (!string.IsNullOrEmpty(user.Address))
                existingUser.Address = user.Address;

            await _dbContext.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> DeleteUserById(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if(usuario == null)
                return false;
            _dbContext.Usuarios.Remove(usuario);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }

    
}
