using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetailsMangement.Controllers
{
    public class StaffLogin : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
