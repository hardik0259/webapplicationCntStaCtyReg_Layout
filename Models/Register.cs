using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapplicationCntStaCtyReg_Layout.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        public Boolean IsSubscribe { get; set; }
        [Display(Name ="City")]
        public int CityId { get; set; }
        public City City { get; set; }
        [NotMapped]
        [Display(Name ="State")]
        public int StateId { get; set; }
        [NotMapped]
        [Display(Name ="Country")]
        public int CountryId { get; set; }
    }
}