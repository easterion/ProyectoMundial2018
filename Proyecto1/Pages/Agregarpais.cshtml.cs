using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto1.Models;

namespace Proyecto1.Pages
{
    public class AgregarpaisModel : PageModel
    {
        [BindProperty]
        public string Nombpais { get; set; }
        [BindProperty]
        public string Nombbandera { get; set; }
        [BindProperty]
        public bool Exequipos { get; set; }       
        
        [BindProperty]
        public List<Equipo> equipos { get; set; }
        int ui;

        public void OnGet()
        {

        }
        //public ActionResult OnPostFotbandera(string imagenBandera,string parametro1)
        public void OnPostFotbandera(string imagenBandera, string parametro1)
        {            
            if ((imagenBandera==null)||(Nombpais == null))
            {
                Console.WriteLine("la imagen o el nombre no fueron introducidos");
                
            }
            else
            {

            }
            Nombbandera = @"~/images/";
            Nombpais = parametro1;                    
            Nombbandera += imagenBandera;            
            equipos.Add(new Equipo() { NomEquipo = Nombpais });
            //Certament.Add(new Equipo() { NomEquipo = Nombpais });
            ui =equipos.Count();
            Exequipos = true;
            //return RedirectToAction("Index");
        }
    }
}