using LenguaLiteratura.src.Application.Abstractions;
using LenguaLiteratura.src.Application.DTOs;
using LenguaLiteratura.src.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LenguaLiteratura.src.Application.Services
{
    public class ReadingService : IReadingService
    {
        private readonly AppDbContext _db;
        public ReadingService(AppDbContext db) => _db = db;

        public IEnumerable<ReadingTextDto> GetTexts(string group) =>
            _db.ReadingTexts.AsNoTracking().Include(t => t.Questions)
               .Where(t => t.Group == group)
               .OrderBy(t => t.Id).ToList()
               .Select(t => new ReadingTextDto(t.Id, t.Title, t.Content,
                   t.Questions.OrderBy(q => q.Id)
                              .Select(q => new ReadingQuestionDto(q.Id, q.Text, q.Options)).ToList()));

        public CheckAnswerResponse? CheckAnswer(int questionId, string answer)
        {
            var q = _db.ReadingQuestions.AsNoTracking().FirstOrDefault(x => x.Id == questionId);
            if (q is null) return null;
            var ok = string.Equals(q.CorrectAnswer, answer.Trim(), StringComparison.Ordinal);
            return new CheckAnswerResponse(ok, q.CorrectAnswer, q.Explanation);
        }
    }
}