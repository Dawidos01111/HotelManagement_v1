using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomTypes
    {
        [Key]
        public int RoomTypeId { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string RoomType { get; set; }
    }
}
