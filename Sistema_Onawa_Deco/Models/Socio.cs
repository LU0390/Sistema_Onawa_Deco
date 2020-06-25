using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Onawa_Deco.Models
{
    public class Socio
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public int TelefonoContacto { get; set; }

        public List<SeminarioSocio> SocioSeminarios { get; set; }

    }
}
