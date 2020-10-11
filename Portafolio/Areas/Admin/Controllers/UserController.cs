using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using Portafolio.Modelos.ViewModels;
using Microsoft.EntityFrameworkCore;
using Portafolio.Datos.Data;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Portafolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        #region API CALLS

       [HttpGet]
       public IActionResult GetAll()
       {
            var userList = _db.ApplicationUsers.Include(u =>u.UnidadInterna).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach(var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.UnidadInterna == null)
                {
                    user.UnidadInterna = new UnidadInterna()
                    {
                        Des_unidad = ""
                    };

                }

            }

            return Json(new{ data = userList });


       }

        [HttpPost]
        public IActionResult LockUnlock ([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error en Bloqueo/Desbloqueo" });
            }
            if(objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //usuario esta bloqueado, vamos a desbloquearlo ahorita we
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Todo nice" });

        }

        #endregion
    }

}

