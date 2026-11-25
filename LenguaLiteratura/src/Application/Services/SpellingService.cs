using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Application.DTOs;
using LenguaLiteratura.src.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LenguaLiteratura.src.Application.Services
{
    public class SpellingService : ISpellingService
    {
        private readonly AppDbContext _db;
        public SpellingService(AppDbContext db) => _db = db;

        public IEnumerable<SpellingExerciseDto> GetExercises(string group) =>
            _db.SpellingExercises.AsNoTracking()
               .Where(e => e.Group == group)
               .OrderBy(e => e.Id).ToList()
               .Select(e => new SpellingExerciseDto(e.Id, e.Sentence, e.Options));

        public CheckAnswerResponse? CheckAnswer(int id, string answer)
        {
            var e = _db.SpellingExercises.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (e is null) return null;
            var ok = string.Equals(e.CorrectAnswer, answer.Trim(), StringComparison.Ordinal);
            return new CheckAnswerResponse(ok, e.CorrectAnswer, e.Explanation);
        }
    }
}