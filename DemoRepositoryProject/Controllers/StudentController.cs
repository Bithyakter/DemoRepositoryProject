using Demo.BLR.Interface;
using Demo.BLR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoRepositoryProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBLR _stdBLR;

        public StudentController(IStudentBLR stdBLR)
        {
            this._stdBLR = stdBLR;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StudentDTO> model = _stdBLR.GetAllStudents().ToList();
            return View("Index", model);
        }
        #endregion

        #region AddEditStudent
        [HttpGet]
        public IActionResult AddEditStudent(int? id)
        {
            StudentDTO model = new StudentDTO();

            if(id.HasValue)
            {
                model = _stdBLR.GetStudent((int) id);
            }

            return PartialView("_AddEditStudent", model);
        }

        [HttpPost]
        public ActionResult AddEditStudent(StudentDTO model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _stdBLR.SaveStudent(model);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        #endregion 

        #region DeleteStudent
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            StudentDTO model = _stdBLR.GetStudent(id);

            return PartialView("_DeleteStudent", model);
        }
        
        [HttpPost]
        public IActionResult DeleteStudent(int id, FormCollection form)
        {
            _stdBLR.DeleteStudent(id);

            return RedirectToAction("Index");
        }
        #endregion

    }
}
