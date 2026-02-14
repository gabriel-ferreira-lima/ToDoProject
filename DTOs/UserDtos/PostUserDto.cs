using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs.UserDtos {
    public class PostUserDto {
        
        [Required(ErrorMessage ="Parametro name é obrigatorio")]
        [MaxLength(100, ErrorMessage = "Parametro name precisa ter no maximo 100 caracteres")]
        [MinLength(3, ErrorMessage ="Parametro name precisa ter ao menos 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Parametro name é obrigatorio")]
        [EmailAddress(ErrorMessage ="Email Invalido")]
        [MaxLength(100, ErrorMessage = "Parametro name precisa ter no maximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parametro password é obrigatorio")]
        [MaxLength(100, ErrorMessage = "Parametro password precisa ter no maximo 100 caracteres")]
        [MinLength(8, ErrorMessage = "Parametro password precisa ter ao menos 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
            ErrorMessage = "A senha deve conter letra maiúscula, minúscula, número e caractere especial")]
        public string Password { get; set; }
    }
}
