﻿
using Marten.Linq.QueryHandlers;
using Marten.Pagination;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Catalog.Api.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber=1, int? PageSize=10) :IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductsHandler(IDocumentSession session,ILogger<GetProductsHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var result = await session.Query<Product>().ToPagedListAsync(query.PageNumber??1,query.PageSize??10,cancellationToken);
            return new GetProductsResult(result);
        }
    }
}
