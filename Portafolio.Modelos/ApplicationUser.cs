using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portafolio.Modelos
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }


        [Display(Name = "Unidad interna")]
        public int? UnidadInternaId { get; set; }

        [ForeignKey("UnidadInternaId")]
        public UnidadInterna UnidadInterna { get; set; }

        [NotMapped]
        public string Role { get; set; }

        
    }
}
