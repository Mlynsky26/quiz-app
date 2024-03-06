using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    
    public class QuizList : PageModel
    {
        private readonly IQuizAdminService _adminService;

        private readonly ILogger _logger;
        public QuizList(IQuizAdminService adminService, ILogger<QuizList> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }
        
        [BindProperty]
        public List<BackendLab01.Quiz> Quizzes { get; set; }

        public void OnGet()
        {
            Quizzes = _adminService.FindAllQuizzes();
        }
    }
}
