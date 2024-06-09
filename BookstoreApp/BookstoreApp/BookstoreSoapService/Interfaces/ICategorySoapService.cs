using Domain.Entities;
using System.ServiceModel;

namespace BookstoreSoapService.Interfaces
{
    [ServiceContract]
    public interface ICategorySoapService
    {
        [OperationContract]
        Task<ICollection<Category>> GetCategoriesAsync();

        [OperationContract]
        Task<Category> GetCategoryAsync(int id);

        [OperationContract]
        Task<bool> CategoryExistsAsync(int categoryId);

        [OperationContract]
        Task<bool> CreateCategoryAsync(Category category);

        [OperationContract]
        Task<bool> UpdateCategoryAsync(Category category);

        [OperationContract]
        Task<bool> DeleteCategoryAsync(int categoryId);

        [OperationContract]
        Task<bool> SaveAsync();
    }
}
