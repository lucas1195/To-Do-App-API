namespace todo_API.DTOs
{
    public class TaskDTO
    {
        public int IdTask { get; set; }
        public string TituloTask { get; set; }
        public string? DescricaoTask { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Prioridade { get; set; }
    }
}
