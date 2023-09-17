using System.Xml.Linq;
using Hosptital_Console.Data.Enums;
using Hosptital_Console.Data.Models;
using Hosptital_Console.Services.Asbtract;

namespace Hosptital_Console.Services.Concrete
{
    public class HospitalService : IHospitalService
    {
        private List<Doctor> doctors = new();
        private List<Patient> patients = new();
        private List<Meeting> meetings = new();

        public int AddDoctor(string fullname, Department department, decimal pricePerSession)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                throw new Exception("Fullname can't be empty!");

            if (pricePerSession < 0)
                throw new Exception("Price per session can't be less than 0!");

            var doctor = new Doctor
            {
                Fullname = fullname,
                Department = department,
                PricePerSession = pricePerSession
            };

            doctors.Add(doctor);

            return doctor.Id;
        }

        public int AddMeeting(int doctorId, int patientId, DateTime date, string reason)
        {
            if (doctorId < 0 || patientId < 0)
                throw new Exception("Id can't be less than 0!");

            if (date < DateTime.Now)
                throw new Exception("Meeting can't be created in past!");

            if (string.IsNullOrWhiteSpace(reason))
                throw new Exception("Reason can't be empty!");

            var doctor = doctors.FirstOrDefault(x => x.Id == doctorId);
            if (doctor is null)
                throw new Exception($"Doctor with ID:{doctorId} was not found!");

            var patient = patients.FirstOrDefault(x => x.Id == patientId);
            if (patient is null)
                throw new Exception($"Patient with ID:{patientId} was not found!");

            var meeting = new Meeting
            {
                Patient = patient,
                Doctor = doctor,
                Date = date,
                Reason = reason
            };

            meetings.Add(meeting);

            return meeting.Id;
        }

        public int AddPatient(string fullname, string phone)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                throw new Exception("Fullname can't be empty!");

            if (string.IsNullOrWhiteSpace(phone))
                throw new Exception("Phone can't be empty!");

            var patient = new Patient
            {
                Fullname = fullname,
                Phone = phone
            };

            patients.Add(patient);

            return patient.Id;
        }

        public int DeleteDoctor(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var doctor = doctors.FirstOrDefault(x => x.Id == id);

            if (doctor is null)
                throw new Exception($"Doctor with ID:{id} was not found!");

            doctors.Remove(doctor);

            return id;
        }

        public int DeleteMeeting(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var meeting = meetings.FirstOrDefault(x => x.Id == id);

            if (meeting is null)
                throw new Exception($"Meeting with ID:{id} was not found!");

            meetings.Remove(meeting);

            return id;
        }

        public int DeletePatient(int id)
        {
            if (id < 0)
                throw new Exception("Id can't be less than 0!");

            var patient = patients.FirstOrDefault(x => x.Id == id);

            if (patient is null)
                throw new Exception($"Patient with ID:{id} was not found!");

            patients.Remove(patient);

            return id;
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        public List<Meeting> GetMeetings()
        {
            return meetings;
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public Report GetReport(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate)
                throw new Exception("Min date can't be larger than max date!");

            var report = new Report();

            meetings.Where(x => x.Date >= minDate && x.Date <= maxDate).ToList().ForEach(x =>
            {
                report.MeetingCount++;
                report.Income += x.Doctor.PricePerSession;
            });

            return report;
        }
    }
}

