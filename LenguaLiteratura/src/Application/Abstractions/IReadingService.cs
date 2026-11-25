using LenguaLiteratura.src.Application.DTOs;

namespace LenguaLiteratura.src.Application.Abstractions
{
    public interface IReadingService
    {
        // Ahora recibe la etapa ("children" o "teenagers") para devolver solo los textos de esa etapa
        IEnumerable<ReadingTextDto> GetTexts(string group);

        CheckAnswerResponse? CheckAnswer(int questionId, string answer);
    }
}