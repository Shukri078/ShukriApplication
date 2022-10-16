using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShukriApplication.Models
{
    public class ScheduleDate
    {
        public ScheduleDate()
        {
            StartDate = DateTime.Now;
        }

        public int ScheduleDateId { get; set; }






        [ForeignKey("ClassRoom")]//very important
        public int ClassRoomId { get; set; }
        public virtual ClassRoom ClassRoom { get; private set; } //very important 









        //Schedule Date
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        //Start Time
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = false)]
        public DateTime StartTime { get; set; }

        //End Time
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = false)]
        public DateTime EndTime { get; set; }

    }
}
