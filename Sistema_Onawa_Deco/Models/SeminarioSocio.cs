using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Onawa_Deco.Models
{
    public class SeminarioSocio
    {
        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        public int SeminarioId { get; set; }
        public Seminario Seminario { get; set; }

    }
}
