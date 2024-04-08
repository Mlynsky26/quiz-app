using ApplicationCore.Interfaces.Criteria;

namespace BackendLab01;

public interface IQuizAdminService
{
    public QuizItem AddQuizItemToQuiz(int quizId, QuizItem item);
    public Quiz AddQuiz(Quiz quiz);
    public void UpdateQuiz(Quiz quiz);
    public void RemoveItemById(int id);
    public bool IsQuizAnswered(int id);
    public IQueryable<QuizItem> FindAllQuizItems();
    public IQueryable<Quiz> FindAllQuizzes();

    public IEnumerable<Quiz> FindBySpecification(ISpecification<Quiz> specification);
}