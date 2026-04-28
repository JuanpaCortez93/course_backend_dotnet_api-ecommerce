using System.ComponentModel.DataAnnotations;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name must exist")]
    [MaxLength(50, ErrorMessage = "Name must have less than 50 chars")]
    [MinLength(3, ErrorMessage = "Name must have more than 3 chars")]
    public string Name { get; set; } = string.Empty;
}