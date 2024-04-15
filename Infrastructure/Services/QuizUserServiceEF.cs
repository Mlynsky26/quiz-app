using AutoMapper;
using BackendLab01;
using Infrastructure.EF.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class QuizUserServiceEF : IQuizUserService
    {
        private QuizDbContext _context;
        private IMapper QuizMapper;
        public QuizUserServiceEF(QuizDbContext context, IMapper mapper)
        {
            _context = context;
            QuizMapper = mapper;
        }

        public Quiz CreateAndGetQuizRandom(int count)
        {
            throw new NotImplementedException();
        }

        public List<Quiz> FindAllQuizzes()
        {
            return _context
            .Quizzes
            .AsNoTracking()
            .Include(q => q.Items)
            .ThenInclude(i => i.IncorrectAnswers)
            .Select(QuizMapper.Map<Quiz>)
            .ToList();
        }

        public Quiz? FindQuizById(int id)
        {
            var entity = _context
            .Quizzes
            .AsNoTracking()
            .Include(q => q.Items)
            .ThenInclude(i => i.IncorrectAnswers)
            .FirstOrDefault(e => e.Id == id);
            return entity is null ? null : QuizMapper.Map<Quiz>(entity);
        }

        public List<QuizItemUserAnswer> GetUserAnswersForQuiz(int quizId, int userId)
        {
            var quizzEntity = _context.Quizzes.AsNoTracking().FirstOrDefault(e => e.Id == quizId);
            if (quizzEntity is null)
                throw new QuizNotFoundException($"Quiz with id {quizId} not found");

            return _context.UserAnswers.Include(a => a.QuizItem).Where(a => a.UserId == userId && a.QuizId == quizId).Select(QuizMapper.Map<QuizItemUserAnswer>).ToList();

        }

        public QuizItemUserAnswer SaveUserAnswerForQuiz(int quizId, int userId, int quizItemId, string answer)
        {
            var quizzEntity = FindQuizById(quizId);
            if (quizzEntity is null)
                throw new QuizNotFoundException($"Quiz with id {quizId} not found");

            var item = quizzEntity.Items.FirstOrDefault(s => s.Id == quizItemId);
            if (item is null)
                throw new QuizItemNotFoundException($"Quiz item with id {quizItemId} not found");

            QuizItemUserAnswerEntity entity = new QuizItemUserAnswerEntity()
            {
                QuizId = quizId,
                UserAnswer = answer,
                UserId = userId,
                QuizItemId = quizItemId
            };
            var savedEntity = _context.Add(entity).Entity;
            _context.SaveChanges();

            return QuizMapper.Map<QuizItemUserAnswer>(entity);
        }
    }
}
