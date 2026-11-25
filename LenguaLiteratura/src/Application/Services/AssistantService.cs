using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Infrastructure;
using static LenguaLiteratura.src.Application.DTOs.AssistantDtos;
using LenguaLiteratura.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LenguaLiteratura.src.Application.Services
{
    public class AssistantService : IAssistantService
    {
        private readonly AppDbContext _db;
        public AssistantService(AppDbContext db) => _db = db;

        private static readonly string[] Farewells = { "fin", "adiós", "adios", "chao", "gracias", "terminar" };
        private static readonly string[] Greetings = { "hola", "buenas", "hey" };

        public AskResponse Ask(string question, string group)
        {
            var q = (question ?? string.Empty).Trim().ToLowerInvariant();
            var teens = group == "teenagers";
            var words = q.Split(new[] { ' ', ',', '.', '!', '¡', '?', '¿' }, StringSplitOptions.RemoveEmptyEntries);

            // Despedida: cierra la conversación
            if (words.Any(w => Farewells.Contains(w)))
                return new AskResponse(teens
                    ? "¡Hasta pronto! Sigue practicando ortografía y lectura."
                    : "¡Chao! Lo hiciste muy bien. ¡Vuelve a practicar pronto!");

            // Saludo
            if (words.Any(w => Greetings.Contains(w)))
                return new AskResponse("¡Hola! Pregúntame sobre tildes, por qué / porque, haber / a ver, mayúsculas, sinónimos u oraciones.");

            // Busca el tema en la base de datos
            var topic = _db.AssistantTopics.AsNoTracking().ToList()
                .FirstOrDefault(t => t.Keywords.Split(',').Any(k => q.Contains(k.Trim().ToLowerInvariant())));

            // Registra la pregunta (sin datos personales) para mejorar el asistente
            _db.AssistantQuestionLogs.Add(new AssistantQuestionLog
            {
                Question = q.Length > 300 ? q[..300] : q,
                Group = teens ? "teenagers" : "children",
                Answered = topic is not null,
                CreatedAt = DateTime.UtcNow
            });
            _db.SaveChanges();

            if (topic is null)
                return new AskResponse(teens
                    ? "Aún no tengo una respuesta para eso, pero ya quedó anotada. Prueba con: tilde, por qué / porque, haber / a ver, mayúsculas, sinónimos, idea principal u oración."
                    : "¡Buena pregunta! Todavía no sé esa, pero la anoté. Pregúntame sobre: tilde, por qué, haber o a ver, mayúsculas, sinónimos u oraciones.");

            return new AskResponse(teens ? topic.TeensAnswer : topic.KidsAnswer);
        }
    }
}