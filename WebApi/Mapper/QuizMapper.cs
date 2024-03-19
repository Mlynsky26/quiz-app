using BackendLab01;
using WebApi.DTO;

namespace WebApi.Mapper;

public class QuizMapper
{
    public static QuizDTO MapQuizToDto(Quiz quiz)
    {
        return new QuizDTO()
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Items = quiz.Items.Select(QuizItemMapper.MapItemToDto).ToList()
        };
    }
}