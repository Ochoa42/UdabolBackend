using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUdabol.DOMAIN.Models.Cis;

public partial class Usuario
{
    public int Id { get; set; } 
    public required string FirstName { get; set; } // 3
    public required string LastName { get; set; }  // 3
    public string Address { get; set; } = null!; // 3
    public string City { get; set; } // 3
    public string Region { get; set; } // 4
    public string PostalCode { get; set; } = null!; // 4
    public required string Country { get; set; } // 4
    public string Phone { get; set; } = null!; 
    public DateTime Birtdate { get; set; } // 3
}
