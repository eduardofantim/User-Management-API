namespace UserManagement.Api.DTOs
{
    public class LoginDto
    {

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]    
        public string Password { get; set; } = string.Empty;
        
    }
}