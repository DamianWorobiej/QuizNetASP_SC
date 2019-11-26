using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNetDataAccess.Models;

namespace QuizNetDataAccess
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly static List<Question> _questions = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Text = "Jakie jest hasło admina?",
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 1,
                        QuestionId = 1,
                        Text = "qwerty"
                    },
                    new Answer()
                    {
                        Id = 2,
                        QuestionId = 1,
                        Text = "admin"
                    },
                    new Answer()
                    {
                        Id = 3,
                        QuestionId = 1,
                        Text = "haslo"
                    },
                    new Answer()
                    {
                        Id = 4,
                        QuestionId = 1,
                        Text = "password"
                    },
                },
                CorrectAnswerIndex = 1
            },
            new Question()
            {
                Id = 2,
                Text = "Jakie jest najlepszy język programowania?",
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 5,
                        QuestionId = 2,
                        Text = "HTML"
                    },
                    new Answer()
                    {
                        Id = 6,
                        QuestionId = 2,
                        Text = "Java"
                    },
                    new Answer()
                    {
                        Id = 7,
                        QuestionId = 2,
                        Text = "C#"
                    },
                    new Answer()
                    {
                        Id = 8,
                        QuestionId = 2,
                        Text = "JavaScript"
                    },
                },
                CorrectAnswerIndex = 2
            },
        };

        public void Add(Question question)
        {
            _questions.Add(question);
        }

        public void Delete(int questionId)
        {
            Question question = _questions.SingleOrDefault(x => x.Id == questionId);
            _questions.Remove(question);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questions;
        }

        public Question GetById(int id)
        {
            return _questions.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Question question)
        {
            Question editedQuestion = _questions.FirstOrDefault(x => x.Id == question.Id);
            int index = _questions.IndexOf(editedQuestion);
            _questions[index] = question;
        }
    }
}
