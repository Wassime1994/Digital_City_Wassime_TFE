using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PatientDTO
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string problem { get; set; }
        public int level { get; set; }
        public DateTime date_entry { get; set; }
        public string statut { get; set; }
    }
}
