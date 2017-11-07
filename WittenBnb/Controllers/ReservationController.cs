using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WittenBnb.Models;

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
                        Email = p.Email,
                        Phone = p.Phone,
                        Notes = p.Notes,
                        CheckIn = p.CheckIn,
                        CheckOut = p.CheckOut,
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
                    Email = reservationViewModel.Email,
                    Phone = reservationViewModel.Phone,
                    Notes = reservationViewModel.Notes
                };

                WittenBnbContext.Reservations.Add(reservation);
                WittenBnbContext.SaveChanges();
            }

            return RedirectToAction("Index");
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