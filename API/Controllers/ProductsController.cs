using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _product_Repo;
        private readonly IGenericRepository<ProductBrand> _product_Brand_Repo;
        private readonly IGenericRepository<ProductType> _product_Type_Repo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> product_repo,
            IGenericRepository<ProductBrand> product_brand_repo,
            IGenericRepository<ProductType> product_type_repo,
            IMapper mapper)
        {
            _product_Repo = product_repo;
            _product_Brand_Repo = product_brand_repo;
            _product_Type_Repo = product_type_repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec =new ProductsWithTypesAndBrandsSpecification();
            var products = await _product_Repo.ListWithSpecAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductAsync(int id)
        {
            var spec =new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _product_Repo.GetEntityWithSpecAsync(spec);
            return _mapper.Map<Product,ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var productBrands= await _product_Brand_Repo.ListAllAsync();
            return Ok(productBrands);
        }
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandAsync(int id)
        {
            return await _product_Brand_Repo.GetByIdAsync(id);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var productBrands= await _product_Type_Repo.ListAllAsync();
            return Ok(productBrands);
        }
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypesAsync(int id)
        {
            return await _product_Type_Repo.GetByIdAsync(id);
        }



    }
}