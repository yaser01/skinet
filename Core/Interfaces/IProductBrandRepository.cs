using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Interfaces
{
    public interface IProductBrandRepository
    {
          Task<ProductBrand> GetProductBrandByIdAsync(int id);
          Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

    }
}