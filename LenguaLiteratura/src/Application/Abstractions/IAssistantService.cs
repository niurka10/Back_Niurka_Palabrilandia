using LenguaLiteratura.src.Application.DTOs;
using static LenguaLiteratura.src.Application.DTOs.AssistantDtos;

namespace LenguaLiteratura.src.Application.Abstractions
{
    public interface IAssistantService
    {
        AskResponse Ask(string question, string group);
    }
}