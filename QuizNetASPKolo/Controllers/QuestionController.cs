﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNetASPKolo.Models;

namespace QuizNetASPKolo.Controllers
{
    public class QuestionController : Controller
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

        public IActionResult GetAll()
        {
            var questions = _questions;
            return View(questions);
        }
    }
}