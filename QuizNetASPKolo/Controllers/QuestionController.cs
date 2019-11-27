using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNetASPKolo.BusinessLogic;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetASPKolo.Models;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        private readonly IQuizService _quizService;

        public QuestionController(IQuestionRepository questionRepository, IQuizService quizService)
        {
            _questionRepository = questionRepository;
            _quizService = quizService;
        }
        public IActionResult GetAll()
        {
            var questions = _questionRepository.GetAll();
            return View(questions);
        }

        public IActionResult Get(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }

        public IActionResult Delete(int id)
        {
            _questionRepository.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult Create()
        {
            QuestionFormViewModel newQuestion = new QuestionFormViewModel();
            return View("QuestionForm", newQuestion);
        }

        public IActionResult Update(int id)
        {
            Question editedQuestion = _questionRepository.GetById(id);
            QuestionFormViewModel newEditedQuestion = new QuestionFormViewModel(editedQuestion);
            return View("QuestionForm", newEditedQuestion);
        }

        [HttpPost]
        public IActionResult Save(QuestionFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("QuestionForm", viewModel);
            }

            if (viewModel.Question.Id == 0)
            {
                _questionRepository.Add(viewModel.GetQuestion());
            }
            else
            {
                _questionRepository.Update(viewModel.GetQuestion());
            }

            return RedirectToAction("Get", new { Id = viewModel.Question.Id });
        }

        public IActionResult GenerateQuiz()
        {
            List<QuestionDto> quiz = _quizService.GenerateQuiz();
            return View("Quiz", quiz);
        }
    }
}
