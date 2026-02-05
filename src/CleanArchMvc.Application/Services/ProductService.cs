using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator  = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(productsQuery);

            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(result);

            return productsDto.ToList();
        }
        //public async Task<ProductDto> GetById(int? id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    var productDto = _mapper.Map<ProductDto>(productEntity);
        //    return productDto;
        //}

        //public async Task<ProductDto> GetProductCategory(int? id)
        //{
        //    var productsCategoryEntity = await _productRepository.GetProductCategory(id);
        //    var productsCategoryDto = _mapper.Map<ProductDto>(productsCategoryEntity);
        //    return productsCategoryDto;
        //}

        //public async Task Add(ProductDto productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.CreateAsync(productEntity);
        //}
        //public async Task Update(ProductDto productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.UpdateAsync(productEntity);
        //}

        //public async Task Remove(int? id)
        //{
        //    var productEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productEntity);
        //}
    }
}