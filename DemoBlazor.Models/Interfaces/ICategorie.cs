using DemoBlazor.Models.DTO;

namespace DemoBlazor.Models.Interfaces;

public  interface ICategorie
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
}
