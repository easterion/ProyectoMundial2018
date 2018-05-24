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
    public class DeleteModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos

        public DeleteModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jugador Jugador { get; set; }
        [BindProperty]
        public Jugador juga { get; set; }
        public static int ide;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ide = id.Value;
            juga = con.mostrarjugador(ide);
            /*eqq = con.mostrareqp(id.Value);
            nomeq = eqq.NomEquipo;
            banequ = eqq.ImagenBandera;*/

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {


            con.RetirarJugador(id.Value);  

            if (id == null)
            {
                return NotFound();
            }

            Jugador = await _context.Juginscr.FindAsync(id);

            if (Jugador != null)
            {
                _context.Juginscr.Remove(Jugador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Equipos/Index");
        }
    }
}
