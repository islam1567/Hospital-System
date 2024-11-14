namespace Hospital_Management_System.Cores.Entities
{
    public class Nurses
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
    }
}
