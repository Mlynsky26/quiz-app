namespace WebApi.DTO
{
    public class QuizSummaryDTO
    {
        public QuizDTO Quiz { get; set; }
        public List<QuizItemUserAnswerDTO> Answers { get; set; }
        public int CorrectTotal { get; set; }
        public int UserId {  get; set; }

    }
}
