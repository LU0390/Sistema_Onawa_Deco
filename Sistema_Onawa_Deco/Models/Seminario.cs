using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Onawa_Deco.Models
{
    public class Seminario
    {
        [Key]
       public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        
        public int Duracion { get; set; }

        public List<ProfesorSeminario> ProfesorSeminarios { get; set; }

        public List<SeminarioSocio> SocioSeminarios { get; set; }

    }
}

