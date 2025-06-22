using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.DAL.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string questions { get; set; }
        public string answer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
