
using Microsoft.AspNetCore.Cors;

using Microsoft.AspNetCore.Mvc;

namespace Clinic_Appointmnet.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
