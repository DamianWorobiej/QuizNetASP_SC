using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.BusinessLogic
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuizService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public int CheckQuiz(List<QuestionDto> questions, int[] userAnswersIds)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                questions[i] = _mapper.Map<QuestionDto>(_questionRepository.GetById(questions[i].Id));
            }

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CorrectAnswerIndex == userAnswersIds[i])
                {
                    correctAnswers++;
                }
            }

            return correctAnswers;
        }

        public List<QuestionDto> GenerateQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

            List<QuestionDto> randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);

            return randomQuestionsDto;
        }

        public List<QuestionDto> GenerateRecentlyAddedQuestionsQuiz()
        {
            List<Question> questions = _questionRepository.GetAll().ToList();
            var randomQuestions = questions.OrderByDescending(x => x.CreatedAt).Take(3).ToList();

            List<QuestionDto> randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);

            return randomQuestionsDto;
        }
    }
}
