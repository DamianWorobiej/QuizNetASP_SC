using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetASPKolo.BusinessLogic.Interfaces;
using QuizNetDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic
{
    class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Add(QuestionDto question)
        {
            _questionRepository.Add(question.ConvertToQuestion());
        }

        public void Delete(int questionId)
        {
            _questionRepository.Delete(questionId);
        }

        public IEnumerable<QuestionDto> GetAll()
        {
            var questionList = _questionRepository.GetAll();
            List<QuestionDto> output = new List<QuestionDto>();

            foreach (var question in questionList)
            {
                output.Add(QuestionDto.FromQuestion(question));
            }

            return output;
        }

        public QuestionDto GetById(int id)
        {
            var question = _questionRepository.GetById(id);
            return QuestionDto.FromQuestion(question);
        }

        public void Update(QuestionDto question)
        {
            _questionRepository.Update(question.ConvertToQuestion());
        }
    }
}
