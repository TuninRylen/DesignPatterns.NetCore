using CQRSDesignPattern.CQRSPattern.Results;
using CQRSDesignPattern.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CQRSDesignPattern.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }


        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x=> new GetProductQueryResult
            {
                ID = x.ID,
                Price = x.Price,
                ProductName = x.Name,
                Stock = x.Stock
            }).ToList();

            return values;
        }

    }
}
