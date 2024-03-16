using CQRSDesignPattern.CQRSPattern.Commands;
using CQRSDesignPattern.CQRSPattern.Handlers;
using CQRSDesignPattern.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDesignPattern.Controllers
{
    public class DefaultController : Controller
    {

        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;

        public DefaultController(GetProductQueryHandler handler, CreateProductCommandHandler createProductCommandHandler, GetProductByIDQueryHandler getProductByIDQueryHandler)
        {
            _getProductQueryHandler = handler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
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

        public IActionResult GetProduct(int id) 
        {
            var values = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);    
        }

    }
}
