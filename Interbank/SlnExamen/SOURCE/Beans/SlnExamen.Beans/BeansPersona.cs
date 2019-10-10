using System;
using System.Collections.Generic;
using System.Text;

namespace SlnExamen.Beans
{
    public class BeansPersona
    {
        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime? FechaProbableMuerte { get; set; }

    }
}
