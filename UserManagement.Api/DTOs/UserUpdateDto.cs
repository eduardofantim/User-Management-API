using System.ComponentModel.DataAnnotations;

namespace UserManagement.Api.DTOs
{
    public class UserUpdateDto
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
    }
}