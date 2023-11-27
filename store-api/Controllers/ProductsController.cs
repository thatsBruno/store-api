using AutoMapper;
using core.Entities;
using core.Interfaces;
using core.Specifications;
using Microsoft.AspNetCore.Mvc;
using store_api.Dto;
using store_api.Helpers;

namespace store_api.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IGenericRepository<Product> _productsRepository;
    private readonly IGenericRepository<ProductBrand> _productsBrandRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<ProductType> _productsTypeRepository;

    public ProductsController(IGenericRepository<Product> productsRepository, IGenericRepository<ProductType> productTypeRepository, IGenericRepository<ProductBrand> productBrandRepository, IMapper mapper)
    {
        _productsBrandRepository = productBrandRepository;
        _mapper = mapper;
        _productsRepository = productsRepository;
        _productsTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

        var countSpec = new ProductWithFiltersForcountSpecification(productParams);

        var totalItems = await _productsRepository.CountAsync(countSpec);

        var products = await _productsRepository.ListAsync(spec);

        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

        return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);

        var product = await _productsRepository.GetEntityWithSpec(spec);

        if (product == null) return NotFound();

        return _mapper.Map<Product, ProductDto>(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _productsBrandRepository.GetAllAsync();

        return Ok(productBrands);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var productTypes = await _productsTypeRepository.GetAllAsync();

        return Ok(productTypes);
    }
}
