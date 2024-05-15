using Marten.Linq.QueryHandlers;
using System.Linq;

namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
   public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var result =await session.Query<Product>().Where(q=>q.Category.Contains(query.Category)).ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(result); 
        }
    }
}
 