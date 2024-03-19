using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    
    public class QuizList : PageModel
    {
        private readonly IQuizUserService _userService;

        private readonly ILogger _logger;
        public QuizList(IQuizUserService userService, ILogger<QuizList> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        [BindProperty]
        public List<BackendLab01.Quiz> Quizzes { get; set; }

        public void OnGet()
        {
            Quizzes = _userService.FindAllQuizzes();
        }
    }
}
