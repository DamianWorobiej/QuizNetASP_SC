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

        public QuestionDto Add(QuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            _questionRepository.Add(question);
            var createdQuestion = _mapper.Map<QuestionDto>(question);
            return createdQuestion;
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

        public QuestionsMetadataDto GetMetadata()
        {
            var allQuestions = _questionRepository.GetAll().ToList();
            var questionsCount = allQuestions.Count;
            DateTime oldestQuestionDate = allQuestions.Min(q => q.CreatedAt).Date;
            DateTime newestQuestionDate = allQuestions.Max(q => q.CreatedAt).Date;

            return new QuestionsMetadataDto()
            { 
                QuestionsCount = questionsCount,
                OldestQuestionDate = oldestQuestionDate,
                NewestQuestionDate = newestQuestionDate
            };
        }
    }
}
