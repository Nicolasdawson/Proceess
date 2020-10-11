using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.Modelos.ViewModels
{
    public class TareaVM
    {
        public Tarea Tarea { get; set; }
        public IEnumerable<SelectListItem> FlujoTareaList { get; set; }

    }
}
