using Portafolio.DataAccess.Repository;
using Portafolio.DataAccess.Repository.IRepository;
using Portafolio.Datos.Data;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portafolio.Datos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TipoFlujo = new TipoFlujoRepository(_db);
            SP_Call = new SP_Call(_db);
            UnidadInterna = new UnidadInternaRepository(_db);
            FlujoTarea = new FlujoTareaRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Tarea = new TareaRepository(_db);
        }

        public ISP_Call SP_Call { get; private set; }

        public ITipoFlujoRepository TipoFlujo { get; private set; }

        public IUnidadInternaRepository UnidadInterna { get; private set; }

        public IFlujoTareaRepository FlujoTarea { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public ITareaRepository Tarea { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}