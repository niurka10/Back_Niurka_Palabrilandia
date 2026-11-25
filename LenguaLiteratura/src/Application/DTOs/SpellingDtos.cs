namespace LenguaLiteratura.src.Application.DTOs;

public record SpellingExerciseDto(int Id, string Sentence, List<string> Options);

public record CheckAnswerRequest(string Answer);

public record CheckAnswerResponse(bool IsCorrect, string CorrectAnswer, string Explanation);