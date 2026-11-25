using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LenguaLiteratura.src.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellingController : ControllerBase
    {
        private readonly ISpellingService _service;

        public SpellingController(ISpellingService service) => _service = service;

        [HttpGet("exercises")]
        public ActionResult<IEnumerable<SpellingExerciseDto>> GetExercises([FromQuery] string group = "children") =>
            Ok(_service.GetExercises(group == "teenagers" ? "teenagers" : "children"));

        [HttpPost("exercises/{id:int}/check")]
        public ActionResult<CheckAnswerResponse> Check(int id, [FromBody] CheckAnswerRequest request)
        {
            var result = _service.CheckAnswer(id, request.Answer);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
