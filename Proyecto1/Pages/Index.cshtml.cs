using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.Models;
using Proyecto1.Data;

namespace Proyecto1.Pages
{
    public class IndexModel : PageModel
    {
        //[Required]
        //[BindProperty]
        /*ConexionBD con = new ConexionBD();
                
        public List<Equipo> Equipos = new List<Equipo>();*/
        public void OnGet()
        {
            /*List<Jugador> jugu = new List<Jugador>();
            if(con.EquipoRegistrado("Peru")>0)
            {
                Console.WriteLine("ya existe el equipo");
            }
            Console.WriteLine();
            Console.WriteLine(con.NumRegistrosEquipo());
            Console.WriteLine(con.NumRegistrosJugador());
            Console.WriteLine();
            foreach(var ui in con.ListaJugadoresEquipo("Italia"))
            {
                Console.WriteLine(ui.Nombre);
            }*/
        }
        public IActionResult OnPost(string Login)
        {

            return RedirectToPage("Contact");
        }
    }
}
