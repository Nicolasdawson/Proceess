using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.DataAccess.Repository.IRepository
{
    public interface IFlujoTareaRepository : IRepository<FlujoTarea>
    {
        void Update(FlujoTarea flujoTarea);
    }
}
