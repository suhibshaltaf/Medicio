using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.DAL.Models
{
    public class Testimonials
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Job { set; get; }
        public string ImageName { get; set; }

        public DateTime CreatedAT { get; set; } = DateTime.Now;
        public bool IsDeleted  { get; set; }
    }
}
