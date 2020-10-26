using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class PaymentTypes
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [DisplayName("Payment Type")]
        [Required(ErrorMessage = "Payment type is required")]
        [Column(TypeName = "nvarchar(50)")]
        public string PaymentType { get; set; }
    }
}
