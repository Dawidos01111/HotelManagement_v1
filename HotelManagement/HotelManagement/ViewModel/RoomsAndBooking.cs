using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.ViewModel
{
    public class RoomsAndBooking
    {
        public IEnumerable<Rooms2> rooms2VM { get; set; }
        public IEnumerable<BookingStatus> bookingStatusesVM { get; set; }
    }
}
