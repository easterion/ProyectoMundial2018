using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1.Data;
using Proyecto1.Models;

namespace Proyecto1.Pages.Equipos
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto1.Data.Certamencontext _context;
        ConexionBD con = new ConexionBD();  // establece la conexion con la base de datos

        public CreateModel(Proyecto1.Data.Certamencontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Equipo Equipo { get; set; }
        public Equipo EquBdd = new Equipo();  // crea un equipo para guardar datos
        [BindProperty]
        public string Nomequ { get; set; }
        [BindProperty]
        public string Eqband { get; set; }
        int contequ = 0;
        public async Task<IActionResult> OnPostAsync()
        {

            contequ = con.NumRegistrosEquipo();
            if (con.EquipoRegistrado(Nomequ) > 0)// verifica que no se repitan los equipos
            {
                Console.WriteLine("ya existe el equipo");
            }
            else
            {
                EquBdd.EquipoID = contequ + 1;
                EquBdd.NomEquipo = Nomequ;
                EquBdd.ImagenBandera = Eqband;

                Equipo.EquipoID = contequ + 1;
                Equipo.NomEquipo = Nomequ;
                Equipo.ImagenBandera = Eqband;
                con.insertarEquipo(EquBdd);
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Equiposins.Add(Equipo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}