using AutoMapper;
using BackendLab01;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/v1/admin/quizzes")]
    public class ApiQuizAdminController : ControllerBase
    {
        private readonly IQuizAdminService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<QuizItem> _validator;

        public ApiQuizAdminController(IQuizAdminService service, IMapper mapper, IValidator<QuizItem> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public IActionResult CreateQuiz(LinkGenerator link, NewQuizDTO dto)
        {
            var quiz = _service.AddQuiz(_mapper.Map<Quiz>(dto));

            return Created(
                link.GetUriByAction(HttpContext, nameof(GetById), null, new { id = quiz.Id }),
                quiz
                );
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Quiz> GetById(int id)
        {
            var result = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPatch]
        [Route("{quizId}")]
        [Consumes("application/json-patch+json")]
        public ActionResult<Quiz> EditQuiz(int quizId, JsonPatchDocument<Quiz>? patchDoc)
        {
            var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
            quiz = JsonSerializer.Deserialize<Quiz>(JsonSerializer.Serialize(quiz));


            if (quiz is null || patchDoc is null)
            {
                return NotFound(new
                {
                    error = $"Quiz with id {quizId} not found"
                });
            }

            if (_service.IsQuizAnswered(quiz.Id))
            {
                return BadRequest(new { error = "Cant edit quiz!" });
            }

            var disabledOperation = patchDoc.Operations.FirstOrDefault(p => p.OperationType == OperationType.Add && p.path == "id");
            if (disabledOperation is not null)
                return BadRequest(new { error = "Cant replace id!" });

            patchDoc.ApplyTo(quiz, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach(var item in quiz.Items)
            {
                var validationResult = _validator.Validate(item);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
            }

            var items = quiz.Items;
            quiz.Items = new List<QuizItem>();

            _service.UpdateQuiz(quiz);

            foreach (var item in items)
            {
                _service.RemoveItemById(item.Id);
                _service.AddQuizItemToQuiz(quizId, item);
            }

            return Ok(_service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId));
        }
    }
}
