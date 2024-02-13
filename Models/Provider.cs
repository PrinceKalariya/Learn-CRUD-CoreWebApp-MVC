using System.ComponentModel.DataAnnotations;

namespace Learn_CRUD_CoreWebApp_MVC.Models
{
    public class Provider
    {
        public Provider()
        {
            this.ProviderServices = new HashSet<ProviderServices>();
        }

        [Key]
        public int ProviderId { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string IsActive { get; set; }    

        public ICollection<ProviderServices> ProviderServices { get; set; }
    }
}
