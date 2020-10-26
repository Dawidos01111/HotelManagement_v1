using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage ="CustomerId is required")]
        public int CustomerId { get; set; }

        [Column(TypeName ="date")]
        [DisplayName("Booking From")]
        [Required(ErrorMessage ="Booking From is required")]
        public string BookingFrom { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Booking To")]
        [Required(ErrorMessage ="Booking To is required")]
        public string BookingTo { get; set; }

        [Required(ErrorMessage ="Room Id is required")]
        [DisplayName("Room Id")]
        public int RoomId { get; set; }

        [Required(ErrorMessage ="Number of members is required")]
        [DisplayName("number of members")]

        public int NumberOfMembers { get; set; }

        [DisplayName("Total amount")]
        public string TotalAmount { get; set; }
    }
}
