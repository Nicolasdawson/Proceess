using Portafolio.Datos.Data;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portafolio.Datos.Repository
{
    public class TipoFlujoRepository : Repository<TipoFlujo>, ITipoFlujoRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoFlujoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TipoFlujo tipoFlujo)
        {
            var objFromDb = _db.Tipoflujos.FirstOrDefault(s => s.Id == tipoFlujo.Id);
            if (objFromDb != null)
            {
                objFromDb.Nom_tipo_flujo = tipoFlujo.Nom_tipo_flujo;

            }
        }
    }
}