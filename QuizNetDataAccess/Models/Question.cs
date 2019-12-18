using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuizNetDataAccess.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public List<Answer> Answers { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
