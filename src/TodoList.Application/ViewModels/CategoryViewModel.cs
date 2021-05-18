using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A descrição deve conter no máximo {0} caracteres.")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
