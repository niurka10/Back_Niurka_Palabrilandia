using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using static LenguaLiteratura.src.Application.DTOs.AssistantDtos;

namespace LenguaLiteratura.src.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssistantController : ControllerBase
    {
        private readonly IAssistantService _service;
        public AssistantController(IAssistantService service) => _service = service;

        [HttpPost("ask")]
        public ActionResult<AskResponse> Ask([FromBody] AskRequest request) =>
            Ok(_service.Ask(request.Question, request.Group == "teenagers" ? "teenagers" : "children"));
    }
}