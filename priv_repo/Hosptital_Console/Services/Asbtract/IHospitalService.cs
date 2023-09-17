using Hosptital_Console.Data.Enums;
using Hosptital_Console.Data.Models;

namespace Hosptital_Console.Services.Asbtract
{
    public interface IHospitalService
    {
        public List<Doctor> GetDoctors();
        public int AddDoctor(string fullname, Department department, decimal pricePerSession);
        public int DeleteDoctor(int id);

        public List<Patient> GetPatients();
        public int AddPatient(string fullname, string phone);
        public int DeletePatient(int id);

        public List<Meeting> GetMeetings();
        public int AddMeeting(int doctorId, int patientId, DateTime date, string reason);
        public int DeleteMeeting(int id);

        public Report GetReport(DateTime minDate, DateTime maxDate);
    }
}