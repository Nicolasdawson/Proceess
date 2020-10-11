using Portafolio.DataAccess.Repository.IRepository;
using Portafolio.Datos.Data;
using Portafolio.Datos.Repository;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portafolio.DataAccess.Repository
{
    public class FlujoTareaRepository : Repository<FlujoTarea>, IFlujoTareaRepository
    {
        private readonly ApplicationDbContext _db;

        public FlujoTareaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FlujoTarea flujoTarea)
        {
            var objFromDb = _db.FlujoTareas.FirstOrDefault(s => s.Id == flujoTarea.Id);
            if (objFromDb != null)
            {
                objFromDb.Nom_flujo = flujoTarea.Nom_flujo;
                objFromDb.Des_flujo = flujoTarea.Des_flujo;
                objFromDb.Progreso = flujoTarea.Progreso;
                objFromDb.TipoFlujoId = flujoTarea.TipoFlujoId;

            }
        }
    }
}
