using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Contentful.Core.Models;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomController(ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            Rooms2 rooms2 = new Rooms2();
            rooms2.ListOfBookingStatus = (from obj in _applicationDbContext.bookingStatuses
                                       select new SelectListItem()
                                       {
                                           Text = obj.BookingStatusName,
                                           Value = obj.BookingStatusId.ToString()
                                       }).ToList();

            rooms2.ListOfRoomType = (from obj in _applicationDbContext.roomTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.RoomTypeName,
                                      Value = obj.RoomTypeId.ToString()
                                  }).ToList();
            //return View(rooms);
            return View(rooms2);
        }

        [HttpGet]
        public IActionResult AddRoom()
        {
           
            return View(new Rooms2());
           //return View(_applicationDbContext.rooms.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRoom(Rooms2 roomsObj)
        {
           
            if (ModelState.IsValid)
            {
                //if (roomsObj.ImageFile != null)
                //{
                //    string folder = "Image/NewRoom";
                //    folder += roomsObj.ImageFile.FileName + Guid.NewGuid().ToString();
                //    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                //    await roomsObj.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                //}

                _applicationDbContext.rooms2s.Add(roomsObj);
                _applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(roomsObj);
        }
    }
}
