using Demo.Bl.InterFace;
using Demo.DaL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace MVC.Pl.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
         
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
          var department = _unitOfWork.department.GetAll();
            return View(department);
        }
        public IActionResult Create()
        {
            return View();  
            
        }
        [HttpPost]
        public IActionResult Create(Deparntment deparntment)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.department.Add(deparntment);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(deparntment);
            }

        }

        public IActionResult Detalis(int id) => ReturnViewName(ViewName: "Detalis", id);


        public IActionResult Edit(int id)=> ReturnViewName(ViewName: "Edit", id);

        [HttpPost]
        public IActionResult Edit(Deparntment deparntment , [FromRoute] int id)
        {
            if(id!= deparntment.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                   _unitOfWork.department.Update(deparntment);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(deparntment);
        }

        public IActionResult Delete(int id)=> ReturnViewName(ViewName: "Delete", id);


        [HttpPost]
        public IActionResult Delete(Deparntment deparntment , [FromRoute] int id)
        {
            if (id != deparntment.Id)
                return BadRequest();
            try
            {
               _unitOfWork.department.Delete(deparntment);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
               ModelState.AddModelError("", ex.Message);
            }            
            return View(deparntment);
        }

        private IActionResult ReturnViewName(string ViewName , int id)
        {
            if (id == null)
                return BadRequest();
            var department = _unitOfWork.department.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(ViewName, department);
        }


    }
}
