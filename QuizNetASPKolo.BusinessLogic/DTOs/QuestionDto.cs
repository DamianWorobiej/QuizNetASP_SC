using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public AnswerDto[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }
    }
}
