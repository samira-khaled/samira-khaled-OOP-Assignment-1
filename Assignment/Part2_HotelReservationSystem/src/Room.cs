using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite
    }
    public class Room
    {
        public int RoomNumber { get; }
        public RoomType RoomType { get; }
        public bool IsUnderMaintenance { get; private set; }
        public decimal NightlyRate { get; private set; }
        private readonly List<Reservation> reservations = new();
        public IReadOnlyList<Reservation> Reservations => reservations;

        public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            IsUnderMaintenance = false;
            if(nightlyRate <= 0)
            {
                throw new ArgumentException("Nightly rate must be greater than zero.", nameof(nightlyRate));
            }
            NightlyRate = nightlyRate;
        }
        public void StartMaintenance()
        {
            IsUnderMaintenance = true;
        }
        public void EndMaintenance()
        {
            IsUnderMaintenance = false;
        }
        public void UpdateNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                throw new ArgumentException("Nightly rate must be greater than zero.", nameof(newRate));
            }
            NightlyRate = newRate;
        }
        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            foreach (var existingReservation in reservations)
            {
                if (existingReservation.Status == ReservationStatus.Cancelled ||existingReservation.Status == ReservationStatus.CheckedOut)
                {
                    continue;
                }
                bool isOverlapping = reservation.CheckInDate < existingReservation.CheckOutDate && reservation.CheckOutDate > existingReservation.CheckInDate;
                if (isOverlapping)
                {
                    throw new InvalidOperationException("The room is already reserved for the specified dates.");
                }
            }
            reservations.Add(reservation);

        }


    }
}
