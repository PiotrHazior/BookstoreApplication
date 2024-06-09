using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;

namespace BookstoreAdmin.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, DataContext context)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            var result = _categoryRepository.CreateCategory(categoryEntity);
            return result;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            var result = _categoryRepository.DeleteCategory(category);
            return result;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = _categoryRepository.GetCategories();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesDto;
        }

        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            var result = _categoryRepository.UpdateCategory(categoryEntity);
            return result;
        }
    }
}
