using Hosptital_Console.Data.Common;
using Hosptital_Console.Data.Enums;

namespace Hosptital_Console.Data.Models
{
    public class Doctor : BaseModel
    {
        private static int id = 0;
        public Doctor()
        {
            Id = id;
            id++;
        }

        public string Fullname { get; set; } = null!;
        public Department Department { get; set; }
        public decimal PricePerSession { get; set; }
    }
}