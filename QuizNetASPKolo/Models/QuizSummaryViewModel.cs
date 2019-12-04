using QuizNetASPKolo.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNetASPKolo.Models
{
    public class QuizSummaryViewModel
    {
        public List<QuestionDto> Questions { get; set; }
        public int[] UserAnswersIndexes { get; set; }
        public int CorrectAnswers { get; set; }
        public double PercentageCorrect
        {
            get
            {
                return 100 * (double)CorrectAnswers / Questions.Count();
            }
        }

        public string SummaryText
        {
            get
            {
                return PercentageCorrect > 50 ? "Well done!" : "Bummer!";
            }
        }

        public string ClassNamesForAnswer(int questionIndex, int answerIndex)
        {
            if (Questions[questionIndex].CorrectAnswerIndex == answerIndex)
            {
                return "list-group-item-success";
            }
            
            if (UserAnswersIndexes[questionIndex] == answerIndex)
            {
                return "list-group-item-danger";
            }

            return string.Empty;
        }
    }
}
