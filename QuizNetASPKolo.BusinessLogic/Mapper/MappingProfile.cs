using AutoMapper;
using QuizNetASPKolo.BusinessLogic.DTOs;
using QuizNetDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNetASPKolo.BusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>();

            CreateMap<AnswerDto, Answer>();
            CreateMap<QuestionDto, Question>();
        }
    }
}
