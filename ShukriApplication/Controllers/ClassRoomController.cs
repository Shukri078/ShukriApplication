using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShukriApplication.Data;
using ShukriApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShukriApplication.Controllers
{
    public class ClassRoomController : Controller
    {

        private readonly ApplicationDbContext _context;

        //private readonly IWebHostEnvironment _webHost;




        public ClassRoomController(ApplicationDbContext context/*, IWebHostEnvironment webHost*/)
        {
            _context = context;
            //_webHost = webHost;

        }

        public IActionResult Index()
        {
            List<ClassRoom> ClassRooms;
            ClassRooms = _context.ClassRooms.ToList();
            return View(ClassRooms);
        }

        public IActionResult Create()
        {
            ClassRoom ClassRoom = new ClassRoom();
            ClassRoom.ScheduleDates.Add(new ScheduleDate() { ScheduleDateId = 1 });
            return View(ClassRoom);
        }

        [HttpPost]
        public IActionResult Create(ClassRoom ClassRoom)
        {

            //foreach (ScheduleDate ScheduleDate in ClassRoom.ScheduleDates)
            //{
            //    if (ScheduleDate.CompanyName == null || ScheduleDate.CompanyName.Length == 0)
            //        ClassRoom.ScheduleDates.Remove(ScheduleDate);
            //}



            _context.Add(ClassRoom);
            _context.SaveChanges();
            return RedirectToAction("index");

        }


        public IActionResult Details(int Id)
        {
            ClassRoom ClassRoom = _context.ClassRooms
                .Include(e => e.ScheduleDates)
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(ClassRoom);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ClassRoom ClassRoom = _context.ClassRooms
                .Include(e => e.ScheduleDates)
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(ClassRoom);
        }
        [HttpPost]
        public IActionResult Delete(ClassRoom ClassRoom)
        {
            _context.Attach(ClassRoom);
            _context.Entry(ClassRoom).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");

        }





        //[HttpGet]
        //public IActionResult Edit(int Id)
        //{
        //    ClassRoom ClassRoom = _context.ClassRooms
        //        .Include(e => e.ScheduleDates)
        //        .Where(a => a.Id == Id).FirstOrDefault();
        //    return View(ClassRoom);
        //}




        //[HttpPost]
        //public IActionResult Edit(ClassRoom ClassRoom)
        //{
        //    //List<ScheduleDate> expDetails = _context.ScheduleDates.Where(d => d.ClassRoomId == ClassRoom.Id).ToList();
        //    //_context.ScheduleDates.RemoveRange(expDetails);
        //    //_context.SaveChanges();

        //    //ClassRoom.ScheduleDates.RemoveAll(n => n.StartDate == 0);


        //    _context.Attach(ClassRoom);
        //    _context.Entry(ClassRoom).State = EntityState.Modified;
        //    _context.ScheduleDates.AddRange(ClassRoom.ScheduleDates);

        //    _context.SaveChanges();
        //    return RedirectToAction("index");
        //}
    }
}