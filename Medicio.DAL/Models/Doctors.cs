using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicio.DAL.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }
        public string jop { get; set; }

        public DateTime CreatedAT { get; set; } = DateTime.Now;
        public int DepartmentId { get; set; }
        public Departments department { get; set; }

    }
}
