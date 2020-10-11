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
    public class UnidadInternaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnidadInternaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            UnidadInterna unidadInterna = new UnidadInterna();
            if (id == null)
            {
                //this is for create
                return View(unidadInterna);
            }
            //this is for edit
            unidadInterna = _unitOfWork.UnidadInterna.Get(id.GetValueOrDefault());
            if (unidadInterna == null)
            {
                return NotFound();
            }
            return View(unidadInterna);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(UnidadInterna unidadInterna)
        {
            if (ModelState.IsValid)
            {
                if (unidadInterna.Id == 0)
                {
                    _unitOfWork.UnidadInterna.Add(unidadInterna);
                    
                }
                else
                {
                    _unitOfWork.UnidadInterna.Update(unidadInterna);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadInterna);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.UnidadInterna.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.UnidadInterna.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error en el eliminación" });
            }
            _unitOfWork.UnidadInterna.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Eliminación exitosa" });

        }

        #endregion
    }
}