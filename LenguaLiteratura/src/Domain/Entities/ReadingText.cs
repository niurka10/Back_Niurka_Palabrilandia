namespace LenguaLiteratura.src.Domain.Entities
{
    public class ReadingText
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<ReadingQuestion> Questions { get; set; } = new();

        // Etapa a la que pertenece el texto: "children" o "teenagers"
        public string Group { get; set; } = "children";
    }

    public class ReadingQuestion
    {
        public int Id { get; set; }
        public int ReadingTextId { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
    }
}