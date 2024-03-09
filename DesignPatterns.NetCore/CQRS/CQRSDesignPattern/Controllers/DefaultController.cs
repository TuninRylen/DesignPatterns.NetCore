using CQRSDesignPattern.CQRSPattern.Commands;
using CQRSDesignPattern.CQRSPattern.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDesignPattern.Controllers
{
    public class DefaultController : Controller
    {

        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;

        public DefaultController(GetProductQueryHandler handler, CreateProductCommandHandler createProductCommandHandler)
        {
            _getProductQueryHandler = handler;
            _createProductCommandHandler = createProductCommandHandler;
        }



        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command) 
        {
            _createProductCommandHandler.Handle(command);
            return View("Index");
        }
    }
}
