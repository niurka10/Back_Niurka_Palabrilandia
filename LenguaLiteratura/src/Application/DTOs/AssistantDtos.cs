namespace LenguaLiteratura.src.Application.DTOs
{
    public class AssistantDtos
    {
        public record AskRequest(string Question, string Group);
        public record AskResponse(string Answer);
    }
}
