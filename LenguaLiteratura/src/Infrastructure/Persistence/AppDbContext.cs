using LenguaLiteratura.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LenguaLiteratura.src.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SpellingExercise> SpellingExercises => Set<SpellingExercise>();
        public DbSet<ReadingText> ReadingTexts => Set<ReadingText>();
        public DbSet<ReadingQuestion> ReadingQuestions => Set<ReadingQuestion>();
        public DbSet<AssistantTopic> AssistantTopics => Set<AssistantTopic>();
        public DbSet<AssistantQuestionLog> AssistantQuestionLogs => Set<AssistantQuestionLog>();
    }
}