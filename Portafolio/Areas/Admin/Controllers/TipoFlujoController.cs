using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;

namespace Portafolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipoFlujoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoFlujoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            TipoFlujo tipoFlujo = new TipoFlujo();
            if (id == null)
            {
                //this is for create
                return View(tipoFlujo);
            }
            //this is for edit
            tipoFlujo = _unitOfWork.TipoFlujo.Get(id.GetValueOrDefault());
            if (tipoFlujo == null)
            {
                return NotFound();
            }
            return View(tipoFlujo);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TipoFlujo tipoFlujo)
        {
            if (ModelState.IsValid)
            {
                if (tipoFlujo.Id == 0)
                {
                    _unitOfWork.TipoFlujo.Add(tipoFlujo);
                    
                }
                else
                {
                    _unitOfWork.TipoFlujo.Update(tipoFlujo);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFlujo);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.TipoFlujo.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.TipoFlujo.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error en el eliminación" });
            }
            _unitOfWork.TipoFlujo.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Eliminación exitosa" });

        }

        #endregion
    }
}