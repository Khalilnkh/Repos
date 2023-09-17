using Hosptital_Console.Data.Common;

namespace Hosptital_Console.Data.Models
{
    public class Patient : BaseModel
    {
        private static int id = 0;
        public Patient()
        {
            Id = id;
            id++;
        }

        public string Fullname { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}

