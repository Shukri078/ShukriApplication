using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using System.Collections.Generic;

namespace ShukriApplication.Models
{
    public class ClassRoom
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Class Name: ")]
        public string ClassName { get; set; }


        //Description of the class
        [Display(Name = "Description: ")]
        public string ClassDescription { get; set; }

        //Lecture name of the class
        [Display(Name = "Lecture Name: ")]
        public string LectureName { get; set; }


        public virtual List<ScheduleDate> ScheduleDates { get; set; } = new List<ScheduleDate>();//detail very important


    }
}
