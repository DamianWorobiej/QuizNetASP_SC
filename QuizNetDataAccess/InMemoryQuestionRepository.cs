using System;
using System.Collections.Generic;
using System.Text;
using QuizNetDataAccess.Models;

namespace QuizNetDataAccess
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        public void Add(Question question)
        {
            throw new NotImplementedException();
        }

        public void Delete(int questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
