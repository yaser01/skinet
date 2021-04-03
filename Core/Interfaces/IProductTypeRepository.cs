using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Interfaces
{
    public interface IProductTypeRepository
    {
          Task<ProductType> GetProductTypeByIdAsync(int id);
          Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}