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
        public int[] UserAnswersIds { get; set; }
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

        public string ProgressBarColor
        {
            get
            {
                return PercentageCorrect > 50 ? "bg-success" : "bg-danger";
            }
        }

        public string ClassNamesForAnswer(AnswerDto answer, int userAnswerIndex)
        {
            if (answer.IsCorrect)
            {
                return "list-group-item-success";
            }
            
            if (UserAnswersIds[userAnswerIndex] == answer.Id)
            {
                return "list-group=item-danger";
            }

            return string.Empty;
        }
    }
}
