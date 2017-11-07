using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WittenBnb.Models
{
    public class ReservationViewModel
    {
        // Int Id must be nullable to allow localDB to generate its own Id
        public int? Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }
        
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }

        [DisplayName("Check In")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check Out")]
        public DateTime CheckOut { get; set; }
    }
}