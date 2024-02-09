namespace Learn_CRUD_CoreWebApp_MVC.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }

        public string FullName { get; set; }

        public DateOnly DateOfRegistration { get; set; }

        public string IsActive { get; set; }    
    }
}
