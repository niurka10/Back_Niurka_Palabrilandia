namespace LenguaLiteratura.src.Domain.Entities
{
    public class AssistantTopic
    {
        public int Id { get; set; }
        public string Keywords { get; set; } = string.Empty;   // separadas por coma: "tilde,acento"
        public string KidsAnswer { get; set; } = string.Empty;
        public string TeensAnswer { get; set; } = string.Empty;
    }

    public class AssistantQuestionLog
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Group { get; set; } = "children";
        public bool Answered { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}