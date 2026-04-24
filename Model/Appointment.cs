using System.Text.Json.Serialization;

namespace Dashboard.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate  { get; set; }
        public int PatientId { get; set; }

        [JsonIgnore]
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }

        [JsonIgnore]
        public Doctor? Doctor { get; set; }
    }
}
