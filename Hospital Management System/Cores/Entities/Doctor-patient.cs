using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Cores.Entities
{
    public class Doctor_patient
    {
        [ForeignKey("Doctors")]
        public string Doctor_Id { get; set; }
        [ForeignKey("Patients")]
        public string Patient_Id { get; set; }
        public Doctors Doctors { get; set; }
        public Patients Patients { get; set; }
    }
}
