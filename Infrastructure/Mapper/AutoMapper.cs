using AutoMapper;
using BackendLab01;
using Infrastructure.EF.Entities;
using System.Collections.Generic;


namespace Infrastructure.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<QuizEntity, Quiz>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(desc => desc.Items, opt => opt.MapFrom<ISet<QuizItemEntity>>(src => src.Items));

            CreateMap<QuizItemEntity, QuizItem>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(desc => desc.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                .ForMember(desc => desc.IncorrectAnswers, opt => opt.MapFrom<ISet<QuizItemAnswerEntity>>(src => src.IncorrectAnswers));

            CreateMap<QuizItemAnswerEntity, string>()
                .ForMember(desc => desc, opt => opt.MapFrom(src => src.Answer));

        }
    }
}
