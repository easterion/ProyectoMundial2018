using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Jugador
    {
        public int JugadorID { get; set; }  // llave primaria
        public string Nombre { get; set; } 
        public string Historia { get; set; }
        public int Posicion { get; set; }
        public DateTime Fechainscripcion { get; set; }
        public ICollection<Inscripcion> InscEquipo { get; set; }
        public string ImagenJug { get; set; }
        public string PaisJugador { get; set; }
        //public Equipo PaisJugador { get; set; }
    }
}

