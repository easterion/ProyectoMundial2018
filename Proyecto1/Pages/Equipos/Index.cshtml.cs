using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        //[Required]
        //[BindProperty]
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos

        public IndexModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public IList<Equipo> Equipo { get;set; }
        public List<Jugador> jugu = new List<Jugador>();
        public List<Equipo> equp = new List<Equipo>();

        public async Task OnGetAsync()
        {
            int cont = 0;
            /*if(con.EquipoRegistrado("Peru")>0)
            {
                Console.WriteLine("ya existe el equipo");
            }
            Console.WriteLine();
            Console.WriteLine(con.NumRegistrosEquipo());
            Console.WriteLine(con.NumRegistrosJugador());
            Console.WriteLine();
            foreach (var ui in con.ListaJugadoresEquipo("Italia"))
            {
                Console.WriteLine(ui.Nombre);
            }*/
            cont = con.NumRegistrosEquipo();
            if(cont>0)// hay por lo menos un equipo registrado
            {
                equp = con.ListaEquipos();
                foreach(var gu in equp)
                {
                    Console.WriteLine("nombre: {0}, bandera: {1}, id: {2}",gu.NomEquipo,gu.ImagenBandera,gu.EquipoID);
                }
            }
            else
            {

            }

            Equipo = await _context.Equiposins.ToListAsync();
        }
    }
}
