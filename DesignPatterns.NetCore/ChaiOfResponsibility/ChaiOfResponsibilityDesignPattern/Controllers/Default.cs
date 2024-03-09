using ChaiOfResponsibilityDesignPattern.ChaiOfResponsibility;
using ChaiOfResponsibilityDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChaiOfResponsibilityDesignPattern.Controllers
{
    public class Default : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer();
            Employee managerAsistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDiractor = new AreaDiractor(); 

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDiractor);

            treasurer.ProcessRequest(model);

            return View();
        }
    }
}
