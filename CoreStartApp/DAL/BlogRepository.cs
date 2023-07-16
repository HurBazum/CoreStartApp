using CoreStartApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CoreStartApp.DAL
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext _blogContext;

        public BlogRepository(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        /// <summary>
        /// добавление юзера
        /// </summary>
        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _blogContext.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                await _blogContext.Users.AddAsync(user);
            }

            // Сохранение изенений
            await _blogContext.SaveChangesAsync();
        }

        /// <summary>
        /// получение всех юзеров
        /// </summary>
        public async Task<User[]> GetUsers()
        {
            return await _blogContext.Users.AsNoTracking().ToArrayAsync();
        }

        public async Task Remove(User user)
        {
            // Добавление пользователя
            var entry = _blogContext.Entry(user);
            if (entry.State == EntityState.Deleted)
            {
                _blogContext.Users.Remove(user);
            }

            // Сохранение изенений
            await _blogContext.SaveChangesAsync();
        }


        // поиск выполняется по индексу, т.к. по айди 
        // надо запоминать много символов
        public async Task<User> GetUser(int? index)
        {
            if(index == null || index < 0)
            {
                return null;
            }

            var u = await GetUsers();

            if(index >= u.Length)
            {
                return null;
            }
            
            return u[Convert.ToInt32(index)];
        }
    }
}