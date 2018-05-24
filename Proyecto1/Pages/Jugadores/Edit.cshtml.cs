using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Jugadores
{
    public class EditModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos
        public static int ide;
        public EditModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jugador juga { get; set; }
        [BindProperty]
        public Jugador Jugador { get; set; }
        [BindProperty]
        public string Jugnom { get; set; }
        [BindProperty]
        public string Histor { get; set; }
        [BindProperty]
        public int Jugpos { get; set; }
        [BindProperty]
        public string Jugima { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ide = id.Value;
            juga = con.mostrarjugador(ide);

            if (id == null)
            {
                return NotFound();
            }

            Jugador = await _context.Juginscr.SingleOrDefaultAsync(m => m.JugadorID == id);

            /*if (Jugador == null)
            {
                return NotFound();
            }*/
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            con.ModJugador(ide,Jugnom, Histor, Jugpos, Jugima);
            

            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(Jugador).State = EntityState.Modified;

            return RedirectToPage("/Equipos/Index");
        }

        private bool JugadorExists(int id)
        {
            return _context.Juginscr.Any(e => e.JugadorID == id);
        }
    }
}
