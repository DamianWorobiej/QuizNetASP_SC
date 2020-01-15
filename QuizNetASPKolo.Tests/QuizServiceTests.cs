using AutoMapper;
using Moq;
using NUnit.Framework;
using QuizNetASPKolo.BusinessLogic;
using QuizNetASPKolo.BusinessLogic.Mapper;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace QuizNetASPKolo.Tests
{
    [TestFixture]
    public class QuizServiceTests
    {
        private Mock<IQuestionRepository> _questionRepositoryMock;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(MappingProfile))));
        }

        [TearDown]
        public void TearDown()
        {
            _questionRepositoryMock = null;
            _mapper = null;
        }

        [Test]
        public void Check_generating_recently_added_questions_quiz()
        {
            IList<Question> questionList = new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Answers = null,
                    CreatedAt = DateTime.Now,
                    Text = "1"
                },
                new Question()
                {
                    Id = 2,
                    Answers = null,
                    CreatedAt = DateTime.Now.AddDays(1),
                    Text = "2"
                },
                new Question()
                {
                    Id = 3,
                    Answers = null,
                    CreatedAt = DateTime.Now.AddDays(2),
                    Text = "3"
                },
            };
            _questionRepositoryMock.Setup(x => x.GetAll()).Returns(questionList);
            var quizService = new QuizService(_questionRepositoryMock.Object, _mapper);

            var quiz = quizService.GenerateRecentlyAddedQuestionsQuiz();

            _questionRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            Assert.AreEqual(3, quiz.FirstOrDefault().Id);
            Assert.AreEqual(3, quiz.Count);

            //Fluent Assertions
            var firstQuestion = quiz.FirstOrDefault();
            firstQuestion.Id.Should().Be(3);
        }
    }
}
