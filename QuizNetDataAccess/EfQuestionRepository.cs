using Microsoft.EntityFrameworkCore;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizNetASPKolo.DataAccess
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly EFDbContext _dbContext;

        public EFQuestionRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
        }

        public void Delete(int questionId)
        {
            var questionToDelete = _dbContext.Questions.Include(x => x.Answers).SingleOrDefault(x => x.Id == questionId);
            _dbContext.Questions.Remove(questionToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return _dbContext.Questions.Include(x => x.Answers).AsEnumerable();
        }

        public Question GetById(int id)
        {
            return _dbContext.Questions.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Question question)
        {
            var questionToUpdate = _dbContext.Questions.Include(x => x.Answers).SingleOrDefault(x => x.Id == question.Id);
            questionToUpdate.Text = question.Text;

            for (int i = 0; i < questionToUpdate.Answers.Count; i++)
            {
                questionToUpdate.Answers[i].IsCorrect = question.Answers[i].IsCorrect;
                question.Answers[i].Text = question.Answers[i].Text;
            }

            _dbContext.SaveChanges();
        }
    }
}
