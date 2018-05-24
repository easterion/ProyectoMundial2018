using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    
    public class Inscripcion
    {
        public int InscripcionID { get; set; }
        public int NomEquipo { get; set; }
        public int NomJugador { get; set; }
        public Equipo Equipoin { get; set; }
        public Jugador Jugadorin { get; set; }
    }
}
