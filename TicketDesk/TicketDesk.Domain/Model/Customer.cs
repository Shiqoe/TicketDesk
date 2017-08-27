using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketDesk.Localization;
using TicketDesk.Localization.Domain;

namespace TicketDesk.Domain.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "FieldMaximumLength", ErrorMessageResourceType = typeof(Validation))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [Display(Name = "Customer_Name", ResourceType = typeof(Strings))]
        public string Name { get; set; }

        [StringLength(10, ErrorMessageResourceName = "FieldMaximumLength", ErrorMessageResourceType = typeof(Validation))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [Display(Name = "Customer_Phone_Number", ResourceType = typeof(Strings))]
        public string PhoneNumber { get; set; }

        [StringLength(20, ErrorMessageResourceName = "FieldMaximumLength", ErrorMessageResourceType = typeof(Validation))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [Display(Name = "Customer_Location", ResourceType = typeof(Strings))]
        public string Location { get; set; }

        [Display(Name = "Customer_Meter_Number", ResourceType = typeof(Strings))]
        public  string MeterNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(ResourceType = typeof(Strings), Name = "Customer_Created_Date", ShortName = "CustomerCreatedDateShort")]
        public DateTimeOffset CreatedDate { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } 
    }
}
