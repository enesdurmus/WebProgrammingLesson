using Microsoft.EntityFrameworkCore;
using SurveySystem.Models;

namespace SurveySystem.Data
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().ToTable("Survey");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<SurveyQuestion>().ToTable("SurveyQuestion");
            modelBuilder.Entity<SurveyResponse>().ToTable("SurveyResponse");
        }
    }
}
