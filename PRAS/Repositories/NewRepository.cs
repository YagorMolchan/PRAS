using PRAS.Data;
using PRAS.Interfaces;
using PRAS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PRAS.Repositories
{
    public class NewRepository : INewRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<New> News => _dbContext.News.ToList();

        public async Task Create(New n)
        {
            _dbContext.News.Add(n);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(New n)
        {
            _dbContext.Entry(n).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(New n)
        {
            _dbContext.Entry(n).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public New GetNew(int id)
        {
            return _dbContext.News.FirstOrDefault(n => n.Id == id);
        }

        public List<New> GetNews(int page, int pageSize)
        {
            return _dbContext.News.OrderByDescending(n => n.Date).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<New> GetNews(int pageSize)
        {
            return _dbContext.News.OrderByDescending(n => n.Date).Take(pageSize).ToList();
        }

        
    }
}
