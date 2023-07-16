using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.IO;
using System.ComponentModel;
using CoreStartApp.Models.Entities;
using CoreStartApp.DAL;

namespace CoreStartApp
{
    public class LogToFileMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LogToFileMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext

            WriteToFile(string.Concat(context.Request.Host.ToUriComponent(), context.Request.Path));

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

        private void WriteToFile(string value)
        {
            FileInfo fi = new(Path.Combine($"{Environment.CurrentDirectory}", "Log.txt"));

            if (!File.Exists(fi.FullName))
            {
                File.Create(fi.FullName);
            }
            else
            {
                File.AppendAllText(fi.FullName, value + "\n");
            }
        }
    }
}