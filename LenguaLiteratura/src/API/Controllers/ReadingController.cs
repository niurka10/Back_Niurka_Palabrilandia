using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LenguaLiteratura.src.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingController : ControllerBase
    {
        private readonly IReadingService _service;
        public ReadingController(IReadingService service) => _service = service;

        [HttpGet("texts")]
        public ActionResult<IEnumerable<ReadingTextDto>> GetTexts([FromQuery] string group = "children") =>
            Ok(_service.GetTexts(group == "teenagers" ? "teenagers" : "children"));

        [HttpPost("questions/{id:int}/check")]
        public ActionResult<CheckAnswerResponse> Check(int id, [FromBody] CheckAnswerRequest request)
        {
            var result = _service.CheckAnswer(id, request.Answer);
            return result is null ? NotFound() : Ok(result);
        }  
    }
}