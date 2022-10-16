using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShukriApplication.Models
{
    public class EditRoleViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Role Name Is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
