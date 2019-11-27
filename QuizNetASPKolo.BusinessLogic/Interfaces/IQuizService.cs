using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic
{
    public interface IQuizService
    {
        List<Question> GenerateQuiz();
    }
}
