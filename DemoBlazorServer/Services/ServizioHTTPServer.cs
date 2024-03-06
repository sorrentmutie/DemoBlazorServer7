using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Interfaces;

namespace DemoBlazorServer.Services;

public class ServizioHTTPServer : ICategorie
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IConfiguration configuration;

    public ServizioHTTPServer(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        this.httpClientFactory = httpClientFactory;
        this.configuration = configuration;
    }

    public Task AddCategory(CategoryCreateDTO category)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDTO>?> GetCategoriesAsync()
    {
        var httpClient = httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(configuration["CategoriesUrl"]);
        if (response.IsSuccessStatusCode)
        {
            return await
                response.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>();
        }
        else
        {
            return null;
        }


    }
}
