using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic
{
    public interface IQuizService
    {
        List<QuestionDto> GenerateQuiz();
        int CheckQuiz(int[] questionIds, int[] userAnswersIds);
    }
}
