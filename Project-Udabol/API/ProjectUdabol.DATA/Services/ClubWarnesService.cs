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
    public class ClubWarnesService
    {
        private readonly UdabolDbContext _dbContext;

        public ClubWarnesService(UdabolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ClubWarnes>> GetClubWarnes()
        {
            return await _dbContext.ClubWarnes.ToListAsync();
        }
        public async Task<ClubWarnes> GetClubWarnesId(int id)
        {
            return await _dbContext.ClubWarnes.FindAsync(id);
        }
    }
}
