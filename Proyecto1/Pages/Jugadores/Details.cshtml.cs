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
    public class DetailsModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;

        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos
        public Jugador juga { get; set; }
        public static int ide;

        public DetailsModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public Jugador Jugador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ide = id.Value;
            if (id == null)
            {
                return NotFound();
            }

            Jugador = await _context.Juginscr.SingleOrDefaultAsync(m => m.JugadorID == id);

            juga = con.mostrarjugador(ide);

            /*if (Jugador == null)
            {
                return NotFound();
            }*/
            return Page();
        }
    }
}
