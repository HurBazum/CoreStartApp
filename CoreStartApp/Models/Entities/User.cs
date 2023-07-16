using System;
using System.ComponentModel.DataAnnotations;

namespace CoreStartApp.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            JoinDate = DateTime.Now;
        }
    }
}