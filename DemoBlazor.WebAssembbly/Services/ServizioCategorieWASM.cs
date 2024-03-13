using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Interfaces;
using System.Net.Http.Json;

namespace DemoBlazor.WebAssembbly.Services;

public class ServizioCategorieWASM : ICategorie
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;

    public ServizioCategorieWASM(HttpClient httpClient, IConfiguration configuration)
    {
        this.httpClient = httpClient;
        this.configuration = configuration;
    }

    public async Task AddCategory(CategoryCreateDTO category)
    {
        await httpClient.PostAsJsonAsync(configuration["CategoriesUrl"], category);
    }

    public async Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync()
    {
        var response = await httpClient.GetAsync(configuration["CategoriesUrl"]);
        if(response.IsSuccessStatusCode)
        {
            return await 
                response.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>();
        } else
        {
            return null;
        }

       
    }

    public async Task UpdateCategory(CategoryDTO category)
    {
       await httpClient.PutAsJsonAsync
            ($"{configuration["CategoriesUrl"]}/{category.Id}", category);
    }
}
