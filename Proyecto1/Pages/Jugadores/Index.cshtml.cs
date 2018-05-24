using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Jugadores
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos
        public List<Jugador> juga = new List<Jugador>();

        public IndexModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public List<Jugador> Jugador { get;set; }
        public Equipo equp;

        public async Task OnGetAsync(int? id)
        {
            int cont = 0;

            equp = con.mostrareqp(id.Value);
            //List<Jugador> juga=con.NumRegistrosJugadores(equp.NomEquipo);
            juga = con.NumRegistrosJugadores(equp.NomEquipo);

            if (juga!=null)// hay por lo menos un equipo registrado
            {
                
                foreach (var gu in juga)
                {
                    Console.WriteLine("nombre: {0}, historia: {1}, id: {2}, imagenjug: {3}", gu.Nombre, gu.Historia, gu.JugadorID,gu.ImagenJug);
                }
            }
            else
            {

            }
            Jugador = await _context.Juginscr.ToListAsync();
        }
    }
}
