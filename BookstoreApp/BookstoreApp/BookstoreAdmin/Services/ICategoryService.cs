using Application.Dto;

namespace BookstoreAdmin.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryDto category);
        Task<bool> UpdateCategoryAsync(CategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
