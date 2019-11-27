using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Answer[] Answers { get; set; }

        public int CorrectAnswerIndex { get; set; }
    }
}
