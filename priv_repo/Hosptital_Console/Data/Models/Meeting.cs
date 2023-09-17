using Hosptital_Console.Data.Common;

namespace Hosptital_Console.Data.Models
{
    public class Meeting : BaseModel
    {
        private static int id = 0;
        public Meeting()
        {
            Id = id;
            id++;
        }

        public Doctor Doctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
        public string Reason { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}