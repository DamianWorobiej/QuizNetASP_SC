using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNetASPKolo.Models
{
    public class QuestionFormViewModel
    {
        public QuestionDto Question{ get; set; }
        public int CorrectAnswerIndex { get; set; }

        public string ActionType { 
            get
            {
                return Question.Id == 0 ? "Create" : "Edit";
            }
        }

        public QuestionFormViewModel()
        {
            Question = new QuestionDto();
        }

        public QuestionFormViewModel(QuestionDto question)
        {
            Question = question;
            CorrectAnswerIndex = Question.Answers.ToList().FindIndex(x => x.IsCorrect);
        }
    }
}
