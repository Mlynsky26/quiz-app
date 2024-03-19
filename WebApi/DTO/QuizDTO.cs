namespace WebApi.DTO;

public class QuizDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<QuizItemDTO> Items { get; set; }
}