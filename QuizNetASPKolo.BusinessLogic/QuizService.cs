using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.BusinessLogic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuizService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public List<QuestionDto> GenerateQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();

            List<QuestionDto> randomQuestionDtos = randomQuestions.Select(x => new QuestionDto()
            {
                Id = x.Id,
                CorrectAnswerIndex = x.CorrectAnswerIndex,
                Text = x.Text,
                Answers = x.Answers.Select(y => new AnswerDto()
                {
                    Id = y.Id,
                    Text = y.Text,
                    QuestionId = y.QuestionId
                }).ToArray()
            }).ToList();
            return randomQuestionDtos;
        }
    }
}
