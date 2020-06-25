using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Onawa_Deco.Models
{
    public class ProfesorSeminario
    {
        public int ProfesorDni { get; set; }
        public Profesor Profesor { get; set; }

        public int SeminarioId { get; set; }
        public Seminario Seminario { get; set; }
    }
}

