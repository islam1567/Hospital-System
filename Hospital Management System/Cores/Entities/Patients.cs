namespace Hospital_Management_System.Cores.Entities
{
    public class Patients
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Doctor_patient> Doctor_Patients { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
    }
}
