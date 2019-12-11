using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.DTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify answer text")]
        public string Text { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
