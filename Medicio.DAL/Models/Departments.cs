using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.DAL.Models
{
    
    public class Departments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string line { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string Tabs {  get; set; }
        public string ImageName { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public ICollection<Doctors
            >  doctors { get; set; }

    }
}
