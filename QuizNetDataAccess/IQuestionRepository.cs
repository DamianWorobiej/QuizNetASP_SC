using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetDataAccess
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        void Add(Question question);
        void Update(Question question);
        void Delete(int questionId);
    }
}
