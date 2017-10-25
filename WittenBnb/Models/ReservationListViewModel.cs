using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WittenBnb.Models
{
    public class ReservationListViewModel
    {
        public List<ReservationViewModel> Reservations { get; set; }
        public int TotalReservations { get; set; }
    }
}