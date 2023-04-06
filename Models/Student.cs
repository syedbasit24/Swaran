using SwaranSoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swaran.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(250)]
        public string AboutYourself { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [FileSize(250 * 1024)]
        [FileTypes("jpg,png")]
        public HttpPostedFileBase Photo { get; set; }




    }
}
