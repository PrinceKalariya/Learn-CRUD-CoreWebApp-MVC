using System.ComponentModel.DataAnnotations;

namespace Learn_CRUD_CoreWebApp_MVC.Models
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string IsActive { get; set; }    
    }
}
