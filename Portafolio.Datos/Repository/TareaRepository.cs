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
    public class TareaRepository : Repository<Tarea>, ITareaRepository
    {
        private readonly ApplicationDbContext _db;

        public TareaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tarea tarea)
        {
            var objFromDb = _db.Tareas.FirstOrDefault(s => s.Id == tarea.Id);
            if (objFromDb != null)
            {
                objFromDb.Nom_tarea = tarea.Nom_tarea;
                objFromDb.Des_tarea = tarea.Des_tarea;
                objFromDb.Progreso_tarea = tarea.Progreso_tarea;
                objFromDb.Aprobacion = tarea.Aprobacion;
                objFromDb.Justificacion = tarea.Justificacion;
                objFromDb.Inicio_tarea = tarea.Inicio_tarea;
                objFromDb.Fin_tarea = tarea.Fin_tarea;
                objFromDb.Comentarios = tarea.Comentarios;
                objFromDb.Retraso = tarea.Retraso;
                objFromDb.FlujoTareaId = tarea.FlujoTareaId;


            }
        }
    }
}
