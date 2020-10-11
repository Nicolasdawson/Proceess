using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portafolio.Modelos
{
    public class FlujoTarea
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [Display(Name = "Nombre")]
        public string Nom_flujo { get; set; }

        [Required]

        [Display(Name = "Descripción")]
        public string Des_flujo { get; set; }

        public int Progreso { get; set; }

        public int TipoFlujoId { get; set; }

        [ForeignKey("TipoFlujoId")]

        public TipoFlujo TipoFlujo { get; set; }

    }
}
