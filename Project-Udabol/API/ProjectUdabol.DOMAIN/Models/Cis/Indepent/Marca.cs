using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DOMAIN.Models.Cis.Indepent
{
    public class Marca
    {
        public int Id { get; set; }

        [StringLength(50)]
        public required string Name { get; set; } = null!;
    }
}
