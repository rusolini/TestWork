using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Dropdownlistmvc.Data;

namespace Dropdownlistmvc.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Gender")]
        public int? GenderId { get; set; }
        [Required]
        [DisplayName("Salary")]
        public int Salary { get; set; }
        [DisplayName("Image")]
        public HttpPostedFileBase Image { get; set; }

        public virtual Gender Genders { get; set; }

        public virtual IEnumerable<Gender> GendersEnum { get; set; }
    }
}