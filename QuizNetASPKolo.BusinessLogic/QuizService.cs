using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<Question> GenerateQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
            return randomQuestions;
        }
    }
}
