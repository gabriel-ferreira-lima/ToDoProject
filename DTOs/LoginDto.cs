using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs {
    public class LoginDto {

        [Required(ErrorMessage = "Parametro name é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parametro password é obrigatorio")]
        public string Password { get; set; }
    }
}
