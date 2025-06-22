using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.DAL.Models
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Type { get; set; }  
        public decimal Price { get; set; } 
        
        public List<string> Features { get; set; }
        public bool Isna { get; set; }

        public bool IsDeleted { get; set; }

    }
}
