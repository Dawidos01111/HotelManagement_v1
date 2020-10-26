using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Rooms2
    {
        public Rooms2()
        {
            BookingStatusList = new List<SelectListItem>();
            RoomTypeList = new List<SelectListItem>();
            ListOfBookingStatus = new List<SelectListItem>();
            ListOfRoomType = new List<SelectListItem>();
        }
        [Key]
        public int RoomId { get; set; }

        [DisplayName("Room Number")]
        [Required(ErrorMessage = "Display name is required")]
        [Column(TypeName = "varchar(5)")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Room price")]
        public decimal RoomPrice { get; set; }

        [Required(ErrorMessage = "Room capacity is required")]
        [DisplayName("Room capacity")]
        public int RoomCapacity { get; set; }

        [Required(ErrorMessage = "Room description is required")]
        [Column(TypeName = "nvarchar(750)")]
        [DisplayName("Room description")]
        public string RoomDescription { get; set; }
        

        [Required(ErrorMessage ="Please select booking status")]
        [DisplayName("Booking status")]
        public int BookingStatusId { get; set; }
        public IEnumerable<SelectListItem> BookingStatusList { get; set; }

        [Required(ErrorMessage ="Please selecr room type")]
        [DisplayName("Room Types")]
        public int RoomTypeId { get; set; }
        public IEnumerable<SelectListItem> RoomTypeList { get; set; }



        public List<SelectListItem> ListOfBookingStatus { get; set; }

        public List<SelectListItem> ListOfRoomType { get; set; }





    }
}
