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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
