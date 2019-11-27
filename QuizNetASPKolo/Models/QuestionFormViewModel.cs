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

        public QuestionFormViewModel(Question question)
        {
            QuestionDto parsedQuestion = new QuestionDto()
            {
                Id = question.Id,
                CorrectAnswerIndex = question.CorrectAnswerIndex,
                Text = question.Text,
                Answers = question.Answers.Select(y => new AnswerDto()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            };
            Question = parsedQuestion;
        }

        public Question GetQuestion()
        {
            return new Question()
            {
                Id = Question.Id,
                CorrectAnswerIndex = Question.CorrectAnswerIndex,
                Text = Question.Text,
                Answers = Question.Answers.Select(y => new Answer()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            };
        }
    }
}
