using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using Portafolio.Modelos.ViewModels;

namespace Portafolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FlujoTareaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlujoTareaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            FlujoTareaVM flujoTareaVM = new FlujoTareaVM()

            {
                FlujoTarea = new FlujoTarea(),
                TipoFlujoList = _unitOfWork.TipoFlujo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nom_tipo_flujo,
                    Value = i.Id.ToString()

                })
            };
            
            if (id == null)
            {
                //this is for create
                return View(flujoTareaVM);
            }
            //this is for edit
            flujoTareaVM.FlujoTarea = _unitOfWork.FlujoTarea.Get(id.GetValueOrDefault());
            if (flujoTareaVM.FlujoTarea == null)
            {
                return NotFound();
            }
            return View(flujoTareaVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(FlujoTareaVM flujoTareaVM)
        {
            if (ModelState.IsValid)
            {
                if (flujoTareaVM.FlujoTarea.Id != 0)
                {
                    FlujoTarea objFromDb = _unitOfWork.FlujoTarea.Get(flujoTareaVM.FlujoTarea.Id);

                }
           

            if (flujoTareaVM.FlujoTarea.Id == 0)
            {
                _unitOfWork.FlujoTarea.Add(flujoTareaVM.FlujoTarea);


            }

            else

            {
                _unitOfWork.FlujoTarea.Update(flujoTareaVM.FlujoTarea);

            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));


            }
            else

            {
                flujoTareaVM.TipoFlujoList = _unitOfWork.TipoFlujo.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nom_tipo_flujo,
                    Value = i.Id.ToString()

                });

                if (flujoTareaVM.FlujoTarea.Id != 0)
                {
                    flujoTareaVM.FlujoTarea = _unitOfWork.FlujoTarea.Get(flujoTareaVM.FlujoTarea.Id);

                }
            }

                return View(flujoTareaVM);
            }

            #region API CALLS

            [HttpGet]
                    public IActionResult GetAll()
                    {
                        var allObj = _unitOfWork.FlujoTarea.GetAll(includeProperties:"TipoFlujo");
                        return Json(new { data = allObj });
                    }

                [HttpDelete]
                public IActionResult Delete(int id)
                {
                    var objFromDb = _unitOfWork.FlujoTarea.Get(id);
                    if (objFromDb == null)
                    {
                        return Json(new { success = false, message = "Error en el eliminación" });
                    }
                    _unitOfWork.FlujoTarea.Remove(objFromDb);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Eliminación exitosa" });

                }
            }
        }

        #endregion
    
