using CQRS_with_MediatR.Context;
using CQRS_with_MediatR.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_with_MediatR.Features.ProductFeatures.Queries
{
 

    public class GetProductByNameQuery : IRequest<Product>
    {
        public string name { get; set; }
        public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQuery, Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByNameQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByNameQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Name == query.name).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
