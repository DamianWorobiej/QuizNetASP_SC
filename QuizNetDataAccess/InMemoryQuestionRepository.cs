using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizNetDataAccess.Models;

namespace QuizNetDataAccess
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private static readonly List<Question> _questions = new List<Question>()
        {
            new Question()
            {
                Id = 1,
                Text = "Jakie jest hasło admina?",
                CorrectAnswerIndex = 1,
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
                        Text = "hasło"

                    },
                    new Answer()
                    {
                        Id = 4,
                        QuestionId = 1,
                        Text = "password"

                    },
                },
                CreatedAt = new DateTime(2019, 07, 11, 18, 45, 00),
                UpdatedAt = new DateTime(2019, 07, 11, 18, 45, 00)
            },
            new Question()
            {
                Id = 2,
                Text = "Jaki jest najlepszy język programowania?",
                CorrectAnswerIndex = 2,
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
                CreatedAt = new DateTime(2019, 07, 11, 18, 45, 01),
                UpdatedAt = new DateTime(2019, 07, 11, 18, 45, 01)
            },
            new Question()
            {
                Id = 3,
                Text = "Jakiej metody HTTP używamy aby pobrać dane z serwera?",
                CorrectAnswerIndex = 3,
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 9,
                        QuestionId = 3,
                        Text = "POST"
                    },
                    new Answer()
                    {
                        Id = 10,
                        QuestionId = 3,
                        Text = "PUT"
                    },
                    new Answer()
                    {
                        Id = 11,
                        QuestionId = 3,
                        Text = "DELETE"
                    },
                    new Answer()
                    {
                        Id = 12,
                        QuestionId = 3,
                        Text = "GET"
                    },
                },
                CreatedAt = new DateTime(2019, 07, 11, 18, 45, 02),
                UpdatedAt = new DateTime(2019, 07, 11, 18, 45, 02)
            },
            new Question()
            {
                Id = 4,
                Text = "Na jakim systemie operacyjnym możemy uruchomić aplikację napisaną w .NET Core?",
                CorrectAnswerIndex = 3,
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 13,
                        QuestionId = 4,
                        Text = "Windows"
                    },
                    new Answer()
                    {
                        Id = 14,
                        QuestionId = 4,
                        Text = "Linux"
                    },
                    new Answer()
                    {
                        Id = 15,
                        QuestionId = 4,
                        Text = "Mac OS"
                    },
                    new Answer()
                    {
                        Id = 16,
                        QuestionId = 4,
                        Text = "Wszystkie wymienione"
                    },
                },
                CreatedAt = new DateTime(2019, 07, 11, 18, 45, 03),
                UpdatedAt = new DateTime(2019, 07, 11, 18, 45, 03)
            },
            new Question()
            {
                Id = 5,
                Text = "Które zdanie najlepiej opisuje kontroler?",
                CorrectAnswerIndex = 2,
                Answers = new Answer[]
                {
                    new Answer()
                    {
                        Id = 17,
                        QuestionId = 5,
                        Text = "Wykonuje operacje przeszukiwania i modyfikacji bazy danych"
                    },
                    new Answer()
                    {
                        Id = 18,
                        QuestionId = 5,
                        Text = "Realizuje algorytmy sztucznej inteligencji"
                    },
                    new Answer()
                    {
                        Id = 19,
                        QuestionId = 5,
                        Text = "Odpowiada na zapytania wysyłane przez klienta"
                    },
                    new Answer()
                    {
                        Id = 20,
                        QuestionId = 5,
                        Text = "Tworzy instancje obiektów zainicjalizowane w kontenerze DI"
                    },
                },
                CreatedAt = new DateTime(2019, 07, 11, 18, 45, 04),
                UpdatedAt = new DateTime(2019, 07, 11, 18, 45, 04)
            }
        };

        public void Add(Question question)
        {
            var lastQuestionId = GetAll().Last().Id;
            question.Id = lastQuestionId + 1;

            var lastAnswerId = GetAll().LastOrDefault().Answers.LastOrDefault().Id;
            for (int i = 0; i < question.Answers.Length; i++)
            {
                question.Answers[i].Id = lastAnswerId + i + 1;
                question.Answers[i].QuestionId = question.Id;
            }

            question.CreatedAt = question.UpdatedAt = DateTime.Now;

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

        public void Update(Question updatedQuestion)
        {
            var questionToEdit = _questions.FirstOrDefault(q => q.Id == updatedQuestion.Id);
            questionToEdit.Text = updatedQuestion.Text;
            questionToEdit.CorrectAnswerIndex = updatedQuestion.CorrectAnswerIndex;

            for (int i = 0; i < updatedQuestion.Answers.Length; i++)
            {
                questionToEdit.Answers[i].Text = updatedQuestion.Answers[i].Text;
            }

            questionToEdit.UpdatedAt = DateTime.Now;
        }
    }
}
