using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System.Cores.Entities
{
    public class Payment
    {
        public string Id  { get; set; }
        public int Amount  { get; set; }
        public string Disease { get; set; }
        [ForeignKey("Patients")]
        public string Patient_Id { get; set; }
        public Patients Patients { get; set; }
    }
}
