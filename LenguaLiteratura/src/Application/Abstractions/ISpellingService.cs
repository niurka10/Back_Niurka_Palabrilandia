using LenguaLiteratura.src.Application.DTOs;

namespace LenguaLiteratura.src.Application.Abstractions
{
    public interface ISpellingService
    {
        IEnumerable<SpellingExerciseDto> GetExercises(string group);
        CheckAnswerResponse? CheckAnswer(int id, string answer);
    }
}
