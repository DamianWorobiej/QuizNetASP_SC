using QuizNetASPKolo.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNetASPKolo.Models
{
    public class QuizViewModel
    {
        public List<QuestionDto> Questions { get; set; }

        public int[] UserAnswersIndexes { get; set; }

        public string QuizType { get; set; }

        public QuizViewModel()
        {

        }

        public QuizViewModel(List<QuestionDto> questions, string quizType)
        {
            Questions = questions;
            UserAnswersIndexes = new int[Questions.Count()];
            QuizType = quizType;
        }
    }
}
