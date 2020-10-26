using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class BookingStatus
    {
        [Key]
        public int BookingStatusId { get; set; }

        [Required(ErrorMessage ="Booking Status is required")]
        [DisplayName("Booking Status")]
        [Column(TypeName ="varchar(100)")]
        public string BookingStatusName {get; set; }

    }
}
