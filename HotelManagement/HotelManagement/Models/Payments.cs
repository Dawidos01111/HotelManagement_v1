using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }

        [DisplayName("Booking Id")]
        [Required(ErrorMessage = "Booking Id is required")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Payment Type Id is required")]
        [DisplayName("Payment Type Id is required")]

        public int PaymentTypeId { get; set; }

        [DisplayName("Payment amount")]
        [Required(ErrorMessage = "Payment amount is required")]
        public string PaymentAmount { get; set; }

        [DisplayName("Is Active ")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
