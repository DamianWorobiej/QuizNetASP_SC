using AutoMapper;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetASPKolo.BusinessLogic.Interfaces;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public void Add(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            _questionRepository.Add(question);
            questionDto.Id = question.Id;
        }

        public void Delete(int questionId)
        {
            _questionRepository.Delete(questionId);
        }

        public IEnumerable<QuestionDto> GetAll()
        {
            var questions = _questionRepository.GetAll();
            var questionsDto = _mapper.Map<List<QuestionDto>>(questions);
            return questionsDto;
        }

        public QuestionDto GetById(int id)
        {
            var question = _questionRepository.GetById(id);
            var questionDto = _mapper.Map<QuestionDto>(question);
            return questionDto;
        }

        public void Update(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            _questionRepository.Update(question);
        }
    }
}
