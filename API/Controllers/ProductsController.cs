using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _product_Repo;
        private readonly IProductBrandRepository _product_Brand_Repo;
        private readonly IProductTypeRepository _product_Type_Repo;

        public ProductsController(
            IProductRepository product_repo,
            IProductBrandRepository product_brand_repo,
            IProductTypeRepository product_type_repo)
        {
            _product_Repo = product_repo;
            _product_Brand_Repo = product_brand_repo;
            _product_Type_Repo = product_type_repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _product_Repo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {

            return await _product_Repo.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productBrands= await _product_Brand_Repo.GetProductBrandsAsync();
            return Ok(productBrands);
        }
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandAsync(int id)
        {
            return await _product_Brand_Repo.GetProductBrandByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productBrands= await _product_Type_Repo.GetProductTypesAsync();
            return Ok(productBrands);
        }
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypesAsync(int id)
        {
            return await _product_Type_Repo.GetProductTypeByIdAsync(id);
        }



    }
}