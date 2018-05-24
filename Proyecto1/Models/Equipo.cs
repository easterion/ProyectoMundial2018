using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Equipo
    {
        public int EquipoID { get; set; }   // llave primaria
        public string NomEquipo { get; set; }
        public List<Jugador> Jugadores = new List<Jugador>();
        public ICollection<Inscripcion> Inscripciones { get; set; }
        public string ImagenBandera { get; set; }
        public void AgregarJugador(Jugador Jug)
        {
            Jugadores.Add(new Jugador());
        }
        public List<Jugador> ListaJugadores()
        {
            return Jugadores;
        }
        //public System.Drawing.Rectangle graphics { get; set; }
    }
}
