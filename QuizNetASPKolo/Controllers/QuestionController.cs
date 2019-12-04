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

            return RedirectToAction("Get", new { Id = question });
        }

        public IActionResult GenerateQuiz()
        {
            List<QuestionDto> quiz = _quizService.GenerateQuiz();
            return View("Quiz", quiz);
        }
    }
}
