using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Onawa_Deco.Models
{
    public class Profesor
    {
        [Key]
        public int Dni { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Mail { get; set; }
        public int Telefono { get; set; }

        public List<ProfesorSeminario> ProfesorSeminarios { get; set; }
    }
}
