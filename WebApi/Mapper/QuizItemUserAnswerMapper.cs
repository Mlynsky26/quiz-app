using BackendLab01;
using WebApi.DTO;

namespace WebApi.Mapper;

public class QuizItemUserAnswerMapper
{
    public static QuizItemUserAnswerDTO MapQuizItemUserAnswerToDto(QuizItemUserAnswer item)
    {
        return new QuizItemUserAnswerDTO()
        {
            Answer = item.Answer,
            QuizItemId = item.QuizItem.Id
        };
    }
}