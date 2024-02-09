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

        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Services Services { get; set; }
    }
}
