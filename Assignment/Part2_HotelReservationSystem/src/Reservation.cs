using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled
    }
    public class Reservation
    {
        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public ReservationStatus Status { get; private set; }
        public Room Room { get; }
        public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            ReservationId = reservationId;
            if(checkInDate >= checkOutDate)
            {
                throw new ArgumentException("Check-in date must be before check-out date.");
            }
            if(room == null)
            {
                throw new ArgumentNullException(nameof(room), "Room cannot be null.");
            }
            if (room.IsUnderMaintenance)
            {
                throw new InvalidOperationException("Cannot reserve a room that is under maintenance.");
            }
            
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Pending;
            Room = room;
        }
        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException("Only pending reservations can be confirmed.");
            }
            Status = ReservationStatus.Confirmed;
        }
        public void CheckIn()
        {
            if(Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException("Cannot check in a reservation that is not confirmed.");
            }
            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if(Status != ReservationStatus.CheckedIn)
            {
                throw new InvalidOperationException("Cannot check out a reservation that is not checked in.");
            }
            Status = ReservationStatus.CheckedOut;
        }

        

        public void Cancel()
        {  
            if(Status != ReservationStatus.Confirmed && Status != ReservationStatus.Pending)
            {
                throw new InvalidOperationException("Cannot cancel a reservation that is already checked in or checked out.");
            }
            Status = ReservationStatus.Cancelled;

        }
        public decimal CalculateTotalCost()
        {
            int totalNights = (CheckOutDate - CheckInDate).Days;
            return totalNights * Room.NightlyRate;
        }

        
    }
}
