using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreStartApp.Models.Entities
{
    [Table("Requests")]
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; } = string.Empty;

        public Request()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id} {Date} {Url}";
        }
    }
}