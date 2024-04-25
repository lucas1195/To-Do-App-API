using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todo_API.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int IdTask { get; set; }
        [StringLength(100)]
        public string? TituloTask { get; set; }
        [StringLength(200)]
        public string? DescricaoTask { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataInicio { get; set; }
        public int? Prioridade { get; set; }
        public bool IsCompleted { get; set; }

    }
}
