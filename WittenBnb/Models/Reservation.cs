using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WittenBnb.Models
{
    public class Reservation
    {
            public Reservation()
            {
            }

            
            public Reservation(int id, string firstname, string lastname, string email, string phone, string notes = null)
            {
                Id = id;
                FirstName = firstname;
                LastName = lastname;
                Email = email;
                Phone = phone;
                Notes = notes;
            }

            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Phone { get; set; }

            [MaxLength(200, ErrorMessage = "The Notes field cannot be longer than 200 characters.")]
            public string Notes { get; set; }
    }
}
