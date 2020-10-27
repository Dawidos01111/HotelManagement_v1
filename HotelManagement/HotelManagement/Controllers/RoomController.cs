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
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(roomsObj);
        }

        public IActionResult Home()
        {
            IEnumerable<Rooms2> objList = _applicationDbContext.rooms2s;
            //IEnumerable<BookingStatus> objListBooking = _applicationDbContext.bookingStatuses;
            //ViewBag.Message = "List";
            //RoomsAndBooking roomwAndBooking = new RoomsAndBooking();
            //roomwAndBooking.bookingStatusesVM = (IEnumerable<BookingStatus>)objList;
            //roomwAndBooking.rooms2VM = (IEnumerable<Rooms2>)objListBooking;




            return View(objList);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Uzyskanie danych z bazy danych o konkretnym id
            var RoomsFromDb = _applicationDbContext.rooms2s.Find(id);
            if (RoomsFromDb == null)
            {
                return NotFound();
            }

            return View(RoomsFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rooms2 rooms2Obj)
        {
            if(ModelState.IsValid)
            {
                _applicationDbContext.rooms2s.Update(rooms2Obj);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(rooms2Obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Uzyskanie danych z bazy danych o konkretnym id
            var RoomsFromDb = _applicationDbContext.rooms2s.Find(id);
            if (RoomsFromDb == null)
            {
                return NotFound();
            }

            return View(RoomsFromDb);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var RoomsFromDb = _applicationDbContext.rooms2s.Find(id);
            if (RoomsFromDb == null)
            {
                return NotFound();
            }
            _applicationDbContext.rooms2s.Remove(RoomsFromDb);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Home");


        }
    }
}
