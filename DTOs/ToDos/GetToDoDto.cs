using System.ComponentModel.DataAnnotations;

namespace TodoList.DTOs.ToDos {
    public class GetToDoDto {

        [Required(ErrorMessage = "Page é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A pagina não deve ser um numero negativo")]
        public int? Page { get; set; }

        [Required(ErrorMessage = "PageSize é obrigatório")]
        [Range(1, 100, ErrorMessage = "A quantidade por pagina não deve exceder 100")]
        public int? PageSize { get; set; }

        [Range(0, 2, ErrorMessage = "IsComplete deve estar entre 0 e 2")]
        public int IsCompleted { get; set; } = 2;

        [Range(0, 5, ErrorMessage = "Priority deve estar entre 0 e 5")]
        public int Priority { get; set; } = 0;
    }
}
