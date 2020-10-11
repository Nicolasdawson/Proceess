using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portafolio.Datos.Repository.IRepository;
using Portafolio.Modelos;
using Portafolio.Modelos.ViewModels;
using System.Linq;

namespace Portafolio.Areas.Admin.Controllers
{
    [Area("Admin")]
        public class TareaController : Controller
        {
            private readonly IUnitOfWork _unitOfWork;

            public TareaController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public IActionResult Index()
            {
                return View();
            }

            public IActionResult Upsert(int? id)
            {
                TareaVM tareaVM = new TareaVM()

                {
                    Tarea = new Tarea(),
                    FlujoTareaList = _unitOfWork.FlujoTarea.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Nom_flujo,
                        Value = i.Id.ToString()

                    })
                };

                if (id == null)
                {
                    //this is for create
                    return View(tareaVM);
                }
                //this is for edit
                tareaVM.Tarea = _unitOfWork.Tarea.Get(id.GetValueOrDefault());
                if (tareaVM.Tarea == null)
                {
                    return NotFound();
                }
                return View(tareaVM);

            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Upsert(TareaVM tareaVM)
            {
                if (ModelState.IsValid)
                {
                    if (tareaVM.Tarea.Id != 0)
                    {
                        Tarea objFromDb = _unitOfWork.Tarea.Get(tareaVM.Tarea.Id);

                    }


                    if (tareaVM.Tarea.Id == 0)
                    {
                        _unitOfWork.Tarea.Add(tareaVM.Tarea);


                    }

                    else

                    {
                        _unitOfWork.Tarea.Update(tareaVM.Tarea);

                    }

                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));


                }
                else

                {
                    tareaVM.FlujoTareaList = _unitOfWork.FlujoTarea.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Nom_flujo,
                        Value = i.Id.ToString()

                    });

                    if (tareaVM.Tarea.Id != 0)
                    {
                        tareaVM.Tarea = _unitOfWork.Tarea.Get(tareaVM.Tarea.Id);

                    }
                }

                return View(tareaVM);
            }

            #region API CALLS

            [HttpGet]
            public IActionResult GetAll()
            {
                var allObj = _unitOfWork.Tarea.GetAll(includeProperties: "FlujoTarea");
                return Json(new { data = allObj });
            }

            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var objFromDb = _unitOfWork.Tarea.Get(id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error en el eliminación" });
                }
                _unitOfWork.Tarea.Remove(objFromDb);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Eliminación exitosa" });

            }
        }
    }

    #endregion


