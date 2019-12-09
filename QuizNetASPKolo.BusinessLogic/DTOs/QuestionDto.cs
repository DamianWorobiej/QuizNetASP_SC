using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please specify question text")]
        [StringLength(300)]
        public string Text { get; set; }

        public AnswerDto[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
