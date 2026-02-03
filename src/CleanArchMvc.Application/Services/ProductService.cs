using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsEntity);
            return productsDto.ToList();
        }
        public async Task<ProductDto> GetById(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(productEntity);
            return productDto;
        }

        public async Task<ProductDto> GetProductCategory(int? id)
        {
            var productsCategoryEntity = await _productRepository.GetProductCategory(id);
            var productsCategoryDto = _mapper.Map<ProductDto>(productsCategoryEntity);
            return productsCategoryDto;
        }

        public async Task Add(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntity);
        }
        public async Task Update(ProductDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }
    }
}