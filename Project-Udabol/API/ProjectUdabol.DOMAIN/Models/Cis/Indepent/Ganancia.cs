using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DOMAIN.Models.Cis.Indepent
{
    public class Ganancia
    {
        public int Id { get; set; }
        public DateTime fecha_Ganancia { get; set; }

        [StringLength(100)]
        public string descripcion { get; set; } = null!;
        public float saldo { get; set; }
    }
}
