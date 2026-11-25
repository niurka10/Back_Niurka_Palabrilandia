namespace LenguaLiteratura.src.Domain.Entities
{
    public class SpellingExercise
    {
        public int Id { get; set; }
        public string Sentence { get; set; } = string.Empty;   // Usa ___ para el espacio en blanco
        public List<string> Options { get; set; } = new();
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;

        public string Group { get; set; } = "children"; // "children" o "teenagers"
    }
}
