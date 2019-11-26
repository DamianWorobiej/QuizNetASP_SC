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
            return View(newQuestion);
        }

        [HttpPost]
        public IActionResult Create(Question question)
        {
            var lastQuestionId = _questionRepository.GetAll().Last().Id;
            question.Id = lastQuestionId + 1;

            var lastAnswerId = _questionRepository.GetAll().LastOrDefault().Answers.LastOrDefault().Id;
            for (int i = 0; i < question.Answers.Length; i++)
            {
                question.Answers[i].Id = lastAnswerId + i + 1;
                question.Answers[i].QuestionId = question.Id;
            }

            _questionRepository.Add(question);

            return RedirectToAction("Get", routeValues: new { Id = question.Id });
        }

        public IActionResult Update(int id)
        {
            Question editedQuestion = _questionRepository.GetById(id);
            return View(editedQuestion);
        }

        [HttpPost]
        public IActionResult Update(Question question)
        {
            _questionRepository.Update(question);
            return RedirectToAction("GetAll");
        }
    }
}
