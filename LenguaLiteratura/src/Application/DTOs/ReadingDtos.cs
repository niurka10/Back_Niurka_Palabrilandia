namespace LenguaLiteratura.src.Application.DTOs;

public record ReadingQuestionDto(int Id, string Text, List<string> Options);
public record ReadingTextDto(int Id, string Title, string Content, List<ReadingQuestionDto> Questions);