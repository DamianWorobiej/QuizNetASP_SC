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

        public int CheckQuiz(int[] questionIds, int[] userAnswersIds)
        {
            int correctAnswers = 0;
            List<Question> questions = new List<Question>();

            foreach (var id in questionIds)
            {
                questions.Add(_questionRepository.GetById(id));
            }

            for (int i = 0; i < questionIds.Length; i++)
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
            var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(2).ToList();

            List<QuestionDto> randomQuestionsDto = _mapper.Map<List<QuestionDto>>(randomQuestions);

            return randomQuestionsDto;
        }
    }
}
