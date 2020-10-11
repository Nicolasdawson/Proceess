using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portafolio.Modelos
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [Display(Name = "Nombre")]
        public string Nom_tarea { get; set; }

        [Required]

        [Display(Name = "Descripción")]
        public string Des_tarea { get; set; }

        [Display(Name = "Progreso")]

        public int Progreso_tarea { get; set; }

        public bool Aprobacion { get; set; }

        public string? Justificacion { get; set; }

        [Required]

        [Display(Name = "Fecha comienzo")]

        public DateTime Inicio_tarea { get; set; }

        [Required]

        [Display(Name = "Fecha fin")]

        public DateTime Fin_tarea { get; set; }

        public string Comentarios { get; set; }

        public bool Retraso { get; set; }

        public int FlujoTareaId { get; set; }

        [ForeignKey("FlujoTareaId")]

        public FlujoTarea FlujoTarea { get; set; }

    }
}