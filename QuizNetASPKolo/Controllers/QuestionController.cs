using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNetASPKolo.BusinessLogic;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetASPKolo.BusinessLogic.Interfaces;
using QuizNetASPKolo.Models;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.Controllers
{
    public class QuestionController : Controller
    {

        private readonly IQuizService _quizService;

        private readonly IQuestionService _questionService;


        public QuestionController(IQuizService quizService, IQuestionService questionService)
        {
            _quizService = quizService;
            _questionService = questionService;
        }
        public IActionResult GetAll()
        {
            var questions = _questionService.GetAll();
            return View(questions);
        }

        public IActionResult Get(int id)
        {
            var question = _questionService.GetById(id);
            return View(question);
        }

        public IActionResult Delete(int id)
        {
            _questionService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            QuestionFormViewModel newQuestion = new QuestionFormViewModel();
            return View("QuestionForm", newQuestion);
        }

        public IActionResult Update(int id)
        {
            QuestionDto editedQuestion = _questionService.GetById(id);
            QuestionFormViewModel newEditedQuestion = new QuestionFormViewModel()
            {
                Question = editedQuestion
            };
            return View("QuestionForm", newEditedQuestion);
        }

        [HttpPost]
        public IActionResult Save(QuestionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("QuestionForm", viewModel);
            }

            var question = viewModel.Question;

            if (question.Id == 0)
            {
                question = _questionService.Add(question);
            }
            else
            {
                _questionService.Update(question);
            }

            return RedirectToAction("Get", new { Id = question.Id });
        }

        public IActionResult GenerateQuiz()
        {
            List<QuestionDto> questionsList = _quizService.GenerateQuiz();
            QuizViewModel quiz = new QuizViewModel(questionsList);
            return View("Quiz", quiz);
        }

        public IActionResult GenerateQuizWithRecentQuestions()
        {
            List<QuestionDto> questionsList = _quizService.GenerateRecentlyAddedQuestionsQuiz();
            QuizViewModel quiz = new QuizViewModel(questionsList);
            return View("Quiz", quiz);
        }

        [HttpPost]
        public IActionResult CheckQuiz(QuizViewModel viewModel)
        {
            var userAnswersIds = viewModel.UserAnswersIndexes;
            var correctAnswers = _quizService.CheckQuiz(viewModel.Questions, userAnswersIds);

            var summaryViewModel = new QuizSummaryViewModel()
            {
                Questions = viewModel.Questions,
                UserAnswersIndexes = viewModel.UserAnswersIndexes,
                CorrectAnswers = correctAnswers
            };

            return View("QuizSummary", summaryViewModel);
        }
    }
}
