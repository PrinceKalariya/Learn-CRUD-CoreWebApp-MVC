using Learn_CRUD_CoreWebApp_MVC.Models;

namespace Learn_CRUD_CoreWebApp_MVC.ViewModels
{
    public class ProviderFormViewModel
    {
        public int ProviderId { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string IsActive { get; set; }

        public int[] ProviderServices { get; set; }
    }
}
