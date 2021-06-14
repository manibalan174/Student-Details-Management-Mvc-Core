using Microsoft.AspNetCore.Mvc;
using StudentDetailsManagement.Core.IService;
using StudentDetailsManagement.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetailsMangement.Controllers
{ 
    public class StudentDetailsController : Controller
    {
        IService _Iservices;
        public StudentDetailsController(IService Iservices)
        {
            _Iservices = Iservices;
        }
        public IActionResult StudentDetailsList()
        {
            var studentDetilasList = _Iservices.listStudents();
            return View(studentDetilasList);
        }
        public IActionResult AddEditStudentDetails(int StudentId = 0)
        {
            if (StudentId != 0)   // reterive Method in List page to Edit Page
            {
                var StudentDetails = _Iservices.StudentDetailsReterive(StudentId);
                return View(StudentDetails);
            }
            else
            {
                return View(); // Normal Add Page
            }
        }

        //Insert
        [HttpPost]
        public ActionResult InsertUpdateStudentDetails(StudentDetailsModal StudentProperties)
         {
            if (StudentProperties != null)
            {
                   _Iservices.SaveAndEditStudentDetails(StudentProperties);
                    return RedirectToAction("StudentDetailsList");
            }
            return RedirectToAction("AddEditStudentDetails");
        }

        public IActionResult StudentDetailDelete(int StudentId = 0)
        {
            if (StudentId != 0)   //Delete For StudentDetails in List Page
            {
                _Iservices.StudentDetailsDelete(StudentId);
            }
            return RedirectToAction("StudentDetailsList");
        }
    }
}
