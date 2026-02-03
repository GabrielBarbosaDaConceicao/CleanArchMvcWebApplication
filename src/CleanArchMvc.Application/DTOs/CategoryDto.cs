using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public sealed class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required.")]
        [MinLength(3, ErrorMessage = "The Name must have at least {1} characters.")]
        [MaxLength(100, ErrorMessage = "The Name must have a maximum of {1} characters.")]
        public string Name { get; set; }
    }
}