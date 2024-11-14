using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Cores.Entities
{
    public class Rooms
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Floor_No { get; set; }
        [ForeignKey("Nurses")]
        public string Nurse_Id { get; set; }
        public ICollection<Nurses> Nurses { get; set; }
        public ICollection<Doctors> Doctors { get; set; }
        public ICollection<Patients> Patients { get; set; }
    }
}
