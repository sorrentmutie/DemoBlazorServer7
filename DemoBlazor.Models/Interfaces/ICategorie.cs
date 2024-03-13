using DemoBlazor.Models.DTO;

namespace DemoBlazor.Models.Interfaces;

public  interface ICategorie
{
    Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync();
    Task AddCategory(CategoryCreateDTO category);
    Task UpdateCategory(CategoryDTO category);
}
