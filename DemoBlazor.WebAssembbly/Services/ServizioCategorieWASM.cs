using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Interfaces;

namespace DemoBlazor.WebAssembbly.Services;

public class ServizioCategorieWASM : ICategorie
{
    public Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }
}
