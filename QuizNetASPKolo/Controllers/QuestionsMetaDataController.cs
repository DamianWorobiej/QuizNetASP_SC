using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetASPKolo.BusinessLogic.Interfaces;

namespace QuizNetASPKolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsMetadataController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsMetadataController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult GetMetadata()
        {
            var metadata = _questionService.GetMetadata();

            if (metadata != null)
            {
                return Ok(metadata);
            }
            return BadRequest();
        }
    }
}