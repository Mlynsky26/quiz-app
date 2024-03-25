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
        public IEnumerable<QuizDTO> FindAll()
        {
            return _service.FindAllQuizzes().Select(QuizMapper.MapQuizToDto);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDTO?> GetOneQuiz(int id)
        {
                var result = _service.FindQuizById(id);
                
                return  result == null ? NotFound() : Ok(QuizMapper.MapQuizToDto(result));
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}/answers")]
        public ActionResult SaveUserAnswer([FromBody] SaveAnswerDTO body, int quizId, int itemId)
        {
            _service.SaveUserAnswerForQuiz(quizId, body.UserId, itemId, body.Answer);

            return Created("uri", null);
        }


        [HttpGet]
        [Route("{quizId}/summary/{userId}")]
        public ActionResult<QuizSummaryDTO?> GetQuizSummaryForUser(int quizId, int userId)
        {
            var quiz = _service.FindQuizById(quizId);
            if (quiz == null) return NotFound();

            var answers = _service.GetUserAnswersForQuiz(quizId, userId);

            return new QuizSummaryDTO()
            {
                Quiz = QuizMapper.MapQuizToDto(quiz),
                Answers = answers.Select(QuizItemUserAnswerMapper.MapQuizItemUserAnswerToDto).ToList(),
                UserId = userId,
                CorrectTotal = _service.CountCorrectAnswersForQuizFilledByUser(quizId, userId)
            };
        }

}