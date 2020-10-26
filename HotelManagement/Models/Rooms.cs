using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        
        [DisplayName("Room Number")]
        [Required(ErrorMessage ="Display name is required")]
        [Column(TypeName ="varchar(5)")]
        public int RoomNumber { get; set; }
        
        [Required(ErrorMessage = "Room Image is required")]
        [Column(TypeName ="nvarchar(550)")]
        public string RoomImage { get; set; }

        [Required(ErrorMessage ="Room Image Url is required")]
        [Column(TypeName = "nvarchar(550)")]
        public string RoomImageUrl { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public string RoomPrice { get; set; }
        public int BookingStatusId { get; set; }
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage ="Room capacity is required")]
        public int RoomCapacity { get; set; }

        [Required(ErrorMessage ="Room description is required")]
        [Column(TypeName = "nvarchar(750)")]
        public string RoomDescription { get; set; }

        [Required(ErrorMessage ="Is Active is required")]
        [DefaultValue(true)]
        public bool IsActiv { get; set; }

    }
}
