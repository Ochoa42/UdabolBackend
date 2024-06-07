using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DOMAIN.Models.Cis.Indepent
{
    public class ClubWarnes
    {
        public int id {  get; set; }
        [StringLength(50)]
        public required string name { get; set; }
        [StringLength(100)]
        public required string Ubicacion { get; set; }
        [StringLength(20)]
        public required string Telefono { get; set; }

    }
}
