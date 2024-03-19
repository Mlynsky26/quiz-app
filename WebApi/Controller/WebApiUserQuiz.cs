using Microsoft.AspNetCore.Mvc;
using BackendLab01;
using WebApi.DTO;
using WebApi.Mapper;

namespace WebApi.Controller;

[Route("/api/v1/user/quizzes/")]
public class WebApiUserQuiz : ControllerBase
{
        private readonly IQuizUserService _service;

        public WebApiUserQuiz(IQuizUserService service)
        { 
                _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDTO?> GetOneQuiz(int id)
        {
                var result = _service.FindQuizById(id);
                
                return  result == null ? NotFound() : QuizMapper.MapQuizToDto(result);
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveUserAnswer(QuizItemUserAnswerDTO answerDto, int quizId, int itemId)
        {
                _service.SaveUserAnswerForQuiz(quizId, answerDto.UserId, itemId, answerDto.Answer);
                return Created("uri", null);
        }

}