using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            var q1 = new List<QuizItem>();
            q1.Add(quizItemRepo.Add(new QuizItem(1, "Ile to 2+2", new List<string>(){"2", "3", "5"}, "4")));
            q1.Add(quizItemRepo.Add(new QuizItem(2, "Ile to 3+2", new List<string>(){"4", "7", "9"}, "5")));
            q1.Add(quizItemRepo.Add(new QuizItem(3, "Ile to 2-12", new List<string>(){"-2", "3", "15"}, "-10")));
            q1.Add(quizItemRepo.Add(new QuizItem(4, "Ile to 8+2", new List<string>(){"7", "13", "0"}, "10")));
            var t1 = quizRepo.Add(new Quiz(1, q1, "Quiz pierwszy"));            
            
            var q2 = new List<QuizItem>();
            q2.Add(quizItemRepo.Add(new QuizItem(5, "Ile to 2-2", new List<string>(){"-2", "13", "2"}, "0")));
            q2.Add(quizItemRepo.Add(new QuizItem(6, "Ile to 0+2", new List<string>(){"14", "3", "0"}, "2")));
            q2.Add(quizItemRepo.Add(new QuizItem(7, "Ile to 2+12", new List<string>(){"2", "4", "15"}, "14")));
            q2.Add(quizItemRepo.Add(new QuizItem(8, "Ile to 9+9", new List<string>(){"8", "10", "16"}, "18")));
            var t2 = quizRepo.Add(new Quiz(2, q2, "Quiz drugi"));
        }
    }
}