using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
         :base(x=>
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)&&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)&&
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
         ) 
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x=>x.Name);
            Console.WriteLine(productParams.Sort);
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {

                    case "nameAsc": 
                        AddOrderBy(x=>x.Name);
                        break;
                    case "nameDesc": 
                        AddOrderByDescending(x=>x.Name);
                        break;
                    case "priceAsc": 
                        Console.WriteLine("dd");
                        AddOrderBy(x=>x.Price);
                        break;
                    case "priceDesc": 
                        AddOrderByDescending(x=>x.Price);
                        break;

                };
            }
            ApplyPaging(
            take:productParams.PageSize,
            skip:(productParams.PageIndex-1)*productParams.PageSize);
        }
        public ProductsWithTypesAndBrandsSpecification(int id)
        : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}