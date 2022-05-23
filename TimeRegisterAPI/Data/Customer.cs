namespace TimeRegisterAPI.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}
