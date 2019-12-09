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

        public static QuestionDto FromQuestion(Question question)
        {
            return new QuestionDto()
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
        }

        public Question ConvertToQuestion()
        {
            return new Question()
            {
                Id = Id,
                CorrectAnswerIndex = CorrectAnswerIndex,
                Text = Text,
                Answers = Answers.Select(y => new Answer()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            };
        }
    }
}
