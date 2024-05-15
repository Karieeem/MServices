using BuildingBlocks.Exceptions;

namespace Catalog.Api.Properties.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid id) :base("Product",id)
        {
                
        }
    }
}
