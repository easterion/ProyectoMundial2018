using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Jugadores
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos
        
        public static int idpais;
        //[BindProperty]
        //public Jugador Jugaaux { get; set; }
        public Jugador Jugaaux = new Jugador();    // auxiliar para acceder a la base de datos ////////////////////////////////////////

        public CreateModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        //public async Task OnGetAsync(int? id)
        
        {
            idpais = id.Value;
            equit = con.mostrareqp(idpais);
            Jugpai = equit.NomEquipo;
            
            return Page();
        }

        [BindProperty]
        public Jugador Jugador { get; set; }

        public Equipo equit { get; set; }
        [BindProperty]
        public int Jugaid { get; set; }
        [BindProperty]
        public string Jugnom { get; set; }
        [BindProperty]
        public string Histor { get; set; }
        [BindProperty]
        public int Jugpos { get; set; }
        [BindProperty]
        public string Jugima { get; set; }
        [BindProperty]
        public string Jugband { get; set; }

        public static string Jugpai;

        int contjug = 0;
        int jugtotal = 0;

        public async Task<IActionResult> OnPostAsync()
        {
            int id;
            contjug = con.NumRegistrosJugador();
            //equit= con.mostrareqp(idpais);    // selecciona el pais con identificador: idpais **********************************************************************************                        

            if (contjug > 0)
            {
           
                while(1==1)
                { 
                    if(contjug == (con.JugadorRegistradoID(contjug)))
                    {
                        contjug++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                contjug = 1;
            }

            Jugaaux.JugadorID =contjug;
            Jugaaux.Nombre = Jugnom;
            Jugaaux.Historia = Histor;
            Jugaaux.Posicion=Jugpos;
            Jugaaux.ImagenJug=Jugima;
            Jugaaux.PaisJugador = Jugpai;

            con.insertarJugador(Jugaaux);
            //insertarJugador(int id, string nombre, string histo, int posi, string fotjug, string pajug)


            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Jugador.PaisJugador = Convert.ToString(Equipo.NomEquipo);
            _context.Juginscr.Add(Jugador);
            await _context.SaveChangesAsync();
            id = idpais;
            return RedirectToPage("/Equipos/Index");
        }
    }
}