namespace Hospital_Management_System.Cores.Entities
{
    public class AuthModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }
        public bool IsAuthentication { get; set; } 
        public List<string> Role {  get; set; }
    }
}
