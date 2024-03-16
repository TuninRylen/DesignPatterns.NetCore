using CQRSDesignPattern.CQRSPattern.Queries;
using CQRSDesignPattern.CQRSPattern.Results;
using CQRSDesignPattern.DAL;

namespace CQRSDesignPattern.CQRSPattern.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Handle(GetProductByIDQuery query)
        {
            var values = _context.Find<Product>(query.ID);

            return new GetProductByIDQueryResult
            {
                Name = values.Name,
                Price = values.Price,
                ID = values.ID,
                Stock = values.Stock
            };
        }
    }
}
