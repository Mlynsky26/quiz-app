using BackendLab01;
using WebApi.DTO;

namespace WebApi.Mapper;

public class QuizItemMapper
{
    public static QuizItemDTO MapItemToDto(QuizItem item)
    {
        return new QuizItemDTO()
        {
            Id = item.Id,
            Question = item.Question,
            Options = new List<string>(item.IncorrectAnswers)
            {
                item.CorrectAnswer,
            }
        };
    }
}