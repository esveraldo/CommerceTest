using System.ComponentModel.DataAnnotations;

namespace CommerceTest.Application.Dtos
{
    public class UserDto
    {  
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
