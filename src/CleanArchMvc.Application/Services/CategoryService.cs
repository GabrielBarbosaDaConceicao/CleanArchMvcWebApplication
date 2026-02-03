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
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
            return categoriesDto.ToList();
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryDto;
        }
        public async Task Add(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }
        public async Task Remove(int? id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(categoryEntity);
        }
    }
}