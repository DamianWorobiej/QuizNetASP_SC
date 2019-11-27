using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNetDataAccess;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
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
            Question newQuestion = new Question();
            return View("QuestionForm", newQuestion);
        }

        public IActionResult Update(int id)
        {
            Question editedQuestion = _questionRepository.GetById(id);
            return View("QuestionForm", editedQuestion);
        }

        [HttpPost]
        public IActionResult Save(Question question)
        {
            if (question.Id == 0)
            {
                _questionRepository.Add(question);
            }
            else
            {
                _questionRepository.Update(question);
            }

            return RedirectToAction("Get", new { Id = question.Id });
        }
    }
}
