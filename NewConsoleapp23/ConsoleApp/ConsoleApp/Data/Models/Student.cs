using System;
using amqp.Data.Common;

namespace amqp.Data.Models
{
    public class Student : BaseModel
    {
        private static int id = 0;

        public Student()
        {
            Id = id;
            id++;
        }

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
    }
}