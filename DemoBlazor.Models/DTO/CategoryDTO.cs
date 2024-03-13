using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models.DTO;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(15, ErrorMessage = "Il nome non può superare 15 caratteri")]
    public string? Name { get; set; } 
    [Required(ErrorMessage ="La descrizione è obbligatorio")]
    public string? Description { get; set; }
}

public class CategoryCreateDTO
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
