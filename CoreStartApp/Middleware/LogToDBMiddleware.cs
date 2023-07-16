using CoreStartApp.DAL;
using CoreStartApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreStartApp.Middlware
{
    public class LogToDBMiddleware
    {
        private readonly RequestDelegate _next;

        public delegate Task h(Request req);

        IRequestRepository _requestRepository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LogToDBMiddleware(RequestDelegate next, IRequestRepository reqRepository)
        {
            _next = next;
            _requestRepository = reqRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        [HttpPost]
        public async Task InvokeAsync(HttpContext context)
        {
             // Для логирования данных о запросе используем свойста объекта HttpContext
             Request r = new() 
             { 
                 Url = string.Concat(context.Request.Host.ToUriComponent(), context.Request.Path) 
             };
             await _requestRepository.AddRequest(r);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}