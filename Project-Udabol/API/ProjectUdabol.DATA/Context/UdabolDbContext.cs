using Microsoft.EntityFrameworkCore;
using ProjectUdabol.DOMAIN.Models.Cis;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DATA.Context
{
    public class UdabolDbContext : DbContext
    {
        public UdabolDbContext(DbContextOptions<UdabolDbContext> options): base(options) 
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ClubWarnes> ClubWarnes { get; set;}
        public DbSet<Ganancia> Ganancias { get; set;}
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
