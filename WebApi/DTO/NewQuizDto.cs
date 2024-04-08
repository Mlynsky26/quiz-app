using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class NewQuizDTO
    {
        [Microsoft.Build.Framework.Required]
        [Length(minimumLength:3, maximumLength:200)]
        public string Title { get; set; }

    }
}
