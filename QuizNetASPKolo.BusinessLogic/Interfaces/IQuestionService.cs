using QuizNetASPKolo.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetAll();
        QuestionDto GetById(int id);
        void Add(QuestionDto question);
        void Update(QuestionDto question);
        void Delete(int questionId);
    }
}
