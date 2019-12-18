using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.DTOs
{
    public class QuestionsMetadataDto
    {
        public int QuestionsCount { get; set; }

        public DateTime OldestQuestionDate { get; set; }

        public DateTime NewestQuestionDate { get; set; }
    }
}
