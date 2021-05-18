using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Application.ViewModels
{
    public class TodoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A descrição deve conter no máximo {0} caracteres.")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Conclusão")]
        public DateTime? DateOfTheConclusion { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        [Display(Name = "Categoria")]
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
