﻿using System.ComponentModel.DataAnnotations;

namespace Learn_CRUD_CoreWebApp_MVC.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }

        public string Caption { get; set; }
    }
}
