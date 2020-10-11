using Portafolio.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.Datos.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISP_Call SP_Call { get; }

        ITipoFlujoRepository TipoFlujo { get; }

        IUnidadInternaRepository UnidadInterna { get; }

        IFlujoTareaRepository FlujoTarea { get; } 

        IApplicationUserRepository ApplicationUser { get; }

        ITareaRepository Tarea { get; }

        void Save();
    }
}
