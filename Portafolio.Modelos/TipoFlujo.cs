using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portafolio.Modelos
{
     public class TipoFlujo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50)]
        public string Nom_tipo_flujo { get; set; }
    }
}
