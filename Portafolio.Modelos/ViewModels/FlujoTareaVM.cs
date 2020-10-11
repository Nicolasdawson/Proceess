using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.Modelos.ViewModels
{
    public class FlujoTareaVM
    {
        public FlujoTarea FlujoTarea { get; set; }
        public IEnumerable<SelectListItem> TipoFlujoList { get; set; }
    }
}
