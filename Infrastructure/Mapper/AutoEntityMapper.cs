using AutoMapper;
using BackendLab01;
using Infrastructure.EF.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Infrastructure.Mapper
{
    public class AutoEntityMapper : Profile
    {
        public AutoEntityMapper()
        {

            //From Entity
            CreateMap<QuizEntity, Quiz>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(desc => desc.Items, opt => opt.MapFrom<ISet<QuizItemEntity>>(src => src.Items));

            CreateMap<QuizItemEntity, QuizItem>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(desc => desc.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                .ForMember(desc => desc.IncorrectAnswers, opt => opt.MapFrom<ISet<QuizItemAnswerEntity>>(src => src.IncorrectAnswers));

            //CreateMap<QuizItemAnswerEntity, string>()
            //   .ForMember(desc => desc, opt => opt.MapFrom(src => src.Answer));

            CreateMap<QuizItemAnswerEntity, string>().ConvertUsing(r => r.Answer);

            CreateMap<QuizItemUserAnswerEntity, QuizItemUserAnswer>()
                .ForMember(desc => desc.QuizId, opt => opt.MapFrom(src => src.QuizId))
                .ForMember(desc => desc.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(desc => desc.Answer, opt => opt.MapFrom(src => src.UserAnswer))
                .ForMember(desc => desc.QuizItem, opt => opt.MapFrom(src => src.QuizItem));

            CreateMap<ISet<object>, List<object>>().ConvertUsing(r => r.Select(i => i).ToList());

            //CreateMap<ISet<object>, List<object>>()
            //   .ForMember(desc => desc, opt => opt.MapFrom(src => src));

            //To entity
            CreateMap<Quiz, QuizEntity > ()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(desc => desc.Items, opt => opt.MapFrom<List<QuizItem>>(src => src.Items));

            CreateMap<QuizItem, QuizItemEntity>()
                .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(desc => desc.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(desc => desc.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                .ForMember(desc => desc.IncorrectAnswers, opt => opt.MapFrom<List<string>>(src => src.IncorrectAnswers));

            CreateMap<string, QuizItemAnswerEntity>()
                .ForMember(desc => desc.Answer, opt => opt.MapFrom(src => src));

            CreateMap<QuizItemUserAnswer, QuizItemUserAnswerEntity>()
                .ForMember(desc => desc.QuizId, opt => opt.MapFrom(src => src.QuizId))
                .ForMember(desc => desc.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(desc => desc.UserAnswer, opt => opt.MapFrom(src => src.Answer))
                .ForMember(desc => desc.QuizItem, opt => opt.MapFrom(src => src.QuizItem));

            //CreateMap<List<object>, ISet<object>>()
            //    .ForMember(desc => desc, opt => opt.MapFrom(src => new HashSet<object>(src)));


            CreateMap<List<object>, ISet<object>>().ConvertUsing(r => new HashSet<object>(r));
        }
    }
}
