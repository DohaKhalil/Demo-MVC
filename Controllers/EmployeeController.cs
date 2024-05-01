using AutoMapper;
using Demo.Bl.InterFace;
using Demo.DaL.Model;
using Demo.DaL.ViweModel;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Pl.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly IEmployeeReposiroy _employeeReposiroy;
        //private readonly IDepartmentRepostiroy _departmentRepostiroy;
        private readonly IMapper _maper;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController( IUnitOfWork unitOfWork , IMapper maper)
        {
            //_employeeReposiroy = employeeReposiroy;
            //_departmentRepostiroy = departmentRepostiroy;
            _maper = maper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(string? searchVaue)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(searchVaue)){
                 employees = _unitOfWork.employee.GetAll();
                return View(_maper.Map<IEnumerable<EmployeeVM>>(employees));
            }
            else
            {
                 employees = _unitOfWork.employee.GetAllByName(e=> e.Name.ToLower().Contains(searchVaue.ToLower()));
                return View(_maper.Map<IEnumerable<EmployeeVM>>(employees));
            }
        }
        public IActionResult Create()
        {
            ViewBag.Department =_unitOfWork.department.GetAll(); 
            return View();

        }
        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVm)
        {
            if (ModelState.IsValid)
            {
              
                var employee = _maper.Map<EmployeeVM, Employee>(employeeVm);
                _unitOfWork.employee.Add(employee);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Department = _unitOfWork.department.GetAll();
                return View(employeeVm);
            }

        }

        public IActionResult Detalis(int id) => ReturnViewName(ViewName: "Detalis", id);


        public IActionResult Edit(int id) => ReturnViewName(ViewName: "Edit", id);

        [HttpPost]
        public IActionResult Edit(EmployeeVM employee, [FromRoute] int id)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.employee.Update(_maper.Map<EmployeeVM , Employee>(employee));
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employee);
        }

        public IActionResult Delete(int id) => ReturnViewName(ViewName: "Delete", id);


        [HttpPost]
        public IActionResult Delete(EmployeeVM employee, [FromRoute] int id)
        {
            if (id != employee.Id)
                return BadRequest();
            try
            {
                _unitOfWork.employee.Delete(_maper.Map<EmployeeVM , Employee>(employee));
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(employee);
        }

        private IActionResult ReturnViewName(string ViewName, int id)
        {
            if (id == null)
                return BadRequest();
            var employee = _unitOfWork.employee.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Department = _unitOfWork.department.GetAll();

            return View(ViewName, _maper.Map<EmployeeVM>(employee));
        }


    }
}
