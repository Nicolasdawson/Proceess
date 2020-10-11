using Portafolio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.Datos.Repository.IRepository
{
    public interface ITipoFlujoRepository : IRepository<TipoFlujo>
    {
        void Update(TipoFlujo tipoFlujo);
    }
}