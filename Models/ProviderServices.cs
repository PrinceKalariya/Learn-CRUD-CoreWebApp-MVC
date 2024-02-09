using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn_CRUD_CoreWebApp_MVC.Models
{
    public class ProviderServices
    {
        [Key]
        public int ProviderServiceId { get; set; }

        public int ServiceId { get; set; }

        public int ProviderId { get; set; }

        [ForeignKey("Provider")]
        public virtual Provider Provider { get; set; }

        [ForeignKey("Services")]
        public virtual Services Services { get; set; }
    }
}
