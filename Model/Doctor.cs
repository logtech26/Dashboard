namespace Dashboard.Model
{
    public class Doctor
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Speciality { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
