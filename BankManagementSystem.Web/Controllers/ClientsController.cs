namespace BankManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using BankManagementSystem.Common.BindingModels.Client;

    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateClientBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                return Json("Successful submit! TODO: Implement client persistence.");
            }
            else
            {
                return View(bindingModel);
            }
        }

    }
}
