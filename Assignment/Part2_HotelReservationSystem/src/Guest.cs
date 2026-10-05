using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {
        
        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        private readonly List<Reservation> reservations = new();

        public IReadOnlyList<Reservation> Reservations => reservations;
        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.", nameof(fullName));
            }
            if(string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be empty.", nameof(phoneNumber));
            }
            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            
        }
        public void MakeReservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            var reservation = new Reservation(reservationId, checkInDate, checkOutDate, room);

            room.AddReservation(reservation);
            reservations.Add(reservation);
        }

    }
}
