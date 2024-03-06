using DemoBlazor.Data.Models;
using DemoBlazor.Models.DTO;
using DemoBlazor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServer.Services;

public class ServizioCategorie : ICategorie
{
    private readonly NorthwindContext northwindContext;

    public ServizioCategorie(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        return await northwindContext.Categories
            .Select(c => new CategoryDTO
            {
                Id = c.CategoryId,
                Name = c.CategoryName,
                Description = c.Description
            })
            .ToListAsync();
    }
}
