using BookstoreSoapService.Interfaces;
using Domain.Entities;

namespace BookstoreSoapService.Services
{
    public class CategorySoapService : ICategorySoapService
    {
        private readonly List<Category> _categories = new List<Category>();

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            return Task.FromResult(_categories.Any(c => c.Id == categoryId));
        }

        public Task<bool> CreateCategoryAsync(Category category)
        {
            _categories.Add(category);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<ICollection<Category>> GetCategoriesAsync()
        {
            return Task.FromResult((ICollection<Category>)_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
