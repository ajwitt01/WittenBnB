using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WittenBnb.Models;
using System.Data.OleDb;
using System.Data.SqlClient;
using System;
using System.Data;


namespace WittenBnb.Controllers
{
    // ReservationController is responsible for interacting with the reservations
    public class ReservationController : Controller
    {
        // Displays a list of current reservations.
        public ActionResult Index()
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservationList = new ReservationListViewModel
                {

                    Reservations = WittenBnbContext.Reservations.Select(p => new ReservationViewModel
                    { 
                        Id = p.Id,
                        LastName = p.LastName,
                        FirstName = p.FirstName,
                        CheckIn = p.CheckIn,
                        CheckOut = p.CheckOut,
                        Email = p.Email,
                        Phone = p.Phone,
                        Notes = p.Notes,
                    }).ToList()
                };

                reservationList.TotalReservations = reservationList.Reservations.Count;

                return View(reservationList);
            }
        }

        // View a specific reservation
        public ActionResult ReservationDetail(int id)
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservation = WittenBnbContext.Reservations.SingleOrDefault(p => p.Id == id);
                if (reservation != null)
                {
                    var reservationViewModel = new ReservationViewModel
                    {
                        Id = reservation.Id,
                        LastName = reservation.LastName,
                        FirstName = reservation.FirstName,
                        CheckIn = reservation.CheckIn,
                        CheckOut = reservation.CheckOut,
                        Email = reservation.Email,
                        Phone = reservation.Phone,
                        Notes = reservation.Notes
                    };

                    return View(reservationViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        // Create a new reservation
        public ActionResult ReservationAdd()
        {
            var reservationViewModel = new ReservationViewModel();

            return View("AddEditReservation", reservationViewModel);
        }

        // Post a new reservation to the database
        [HttpPost]
        public ActionResult AddReservation(ReservationViewModel reservationViewModel)
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservation = new Reservation
                {
                    FirstName = reservationViewModel.FirstName,
                    LastName = reservationViewModel.LastName,
                    CheckIn = reservationViewModel.CheckIn,
                    CheckOut = reservationViewModel.CheckOut,
                    Email = reservationViewModel.Email,
                    Phone = reservationViewModel.Phone,
                    Notes = reservationViewModel.Notes
                };

                // RESERVATION CONFLICT TEST BEGIN
                using (var connection = new SqlConnection("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=WittenBnb;integrated security=True;MultipleActiveResultSets=True;App=WittenBnb"))
                {
                    bool conflict = false;
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT CheckIn, CheckOut FROM dbo.Reservations";

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {                               
                            int? checkInConflict = null;
                            int? checkOutConflict = null;
                            while (reader.Read())
                            {
                                var CheckIn = reader.GetDateTime(0);
                                var CheckOut = reader.GetDateTime(1);
                                DateTime value1 = Convert.ToDateTime(CheckIn);
                                DateTime value2 = Convert.ToDateTime(CheckOut);
                                checkInConflict = null;
                                checkOutConflict = null;
                                checkInConflict = DateTime.Compare(reservation.CheckIn, value2);
                                checkOutConflict = DateTime.Compare(reservation.CheckOut, value1);

                                if ((checkInConflict <= 0 | checkOutConflict <= 0) && checkInConflict != checkOutConflict)        
                                {
                                    conflict = true;
                                    break;
                                }
                                else
                                {
                                    conflict = false;
                                }
                            }
                            if (conflict)
                            {
                                // Declare an error of some fashion here.

                            }
                            else
                            {
                                WittenBnbContext.Reservations.Add(reservation);
                                WittenBnbContext.SaveChanges();
                            }
                        }
                        connection.Close();
                    }
                    // RESERVATION CONFLICT TEST END
                }
                return RedirectToAction("Index");
            }
        }

        // Change a reservation's details
        public ActionResult ReservationEdit(int id)
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservation = WittenBnbContext.Reservations.SingleOrDefault(p => p.Id == id);
                if (reservation != null)
                {
                    var reservationViewModel = new ReservationViewModel
                    {
                        Id = reservation.Id,
                        FirstName = reservation.FirstName,
                        LastName = reservation.LastName,
                        CheckIn = reservation.CheckIn,
                        CheckOut = reservation.CheckOut,
                        Email = reservation.Email,
                        Phone = reservation.Phone,
                        Notes = reservation.Notes
                    };

                    return View("AddEditReservation", reservationViewModel);
                }
            }

            return new HttpNotFoundResult();
        }

        // Post changes to a reservation to the database
        [HttpPost]
        public ActionResult EditReservation(ReservationViewModel reservationViewModel)
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservation = WittenBnbContext.Reservations.SingleOrDefault(p => p.Id == reservationViewModel.Id);

                if (reservation != null)
                {
                    reservation.LastName = reservationViewModel.LastName;
                    reservation.FirstName = reservationViewModel.FirstName;
                    reservation.CheckIn = reservationViewModel.CheckIn;
                    reservation.CheckOut = reservationViewModel.CheckOut;
                    reservation.Email = reservationViewModel.Email;
                    reservation.Phone = reservationViewModel.Phone;
                    reservation.Notes = reservationViewModel.Notes;
                    WittenBnbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }

        // Delete a reservation from the database
        [HttpPost]
        public ActionResult DeleteReservation(ReservationViewModel reservationViewModel)
        {
            using (var WittenBnbContext = new WittenBnbContext())
            {
                var reservation = WittenBnbContext.Reservations.SingleOrDefault(p => p.Id == reservationViewModel.Id);

                if (reservation != null)
                {
                    WittenBnbContext.Reservations.Remove(reservation);
                    WittenBnbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return new HttpNotFoundResult();
        }
    }
}