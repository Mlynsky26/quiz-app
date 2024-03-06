using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    private readonly IQuizUserService _userService;

    private readonly ILogger _logger;
    public Summary(IQuizUserService userService, ILogger<Summary> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [BindProperty]
    public int QuizId { get; set; }
    
    [BindProperty]
    public List<QuizItemUserAnswer> QuizAnswers { get; set; }   
    
    [BindProperty]
    public BackendLab01.Quiz Quiz { get; set; }
    public void OnGet(int quizId)
    {
        QuizId = quizId;
        Quiz = _userService.FindQuizById(quizId);
        if (Quiz is not null)
        {
            QuizAnswers = _userService.GetUserAnswersForQuiz(QuizId, 1);
        }
    }
}