namespace Part2_HotelReservationSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var room = new Room(101, RoomType.Double, 1000);

            var guest = new Guest(
                1,
                "Mona Ahmed",
                "01012345678");

            guest.MakeReservation(
                1,
                new DateTime(2026, 10, 10),
                new DateTime(2026, 10, 15),
                room);

            var reservation = guest.Reservations[0];

            Console.WriteLine($"Guest: {guest.FullName}");
            Console.WriteLine($"Room: {room.RoomNumber}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Total: {reservation.CalculateTotalCost()}");

            reservation.Confirm();
            Console.WriteLine($"After Confirm: {reservation.Status}");

            reservation.CheckIn();
            Console.WriteLine($"After Check-In: {reservation.Status}");

            reservation.CheckOut();
            Console.WriteLine($"After Check-Out: {reservation.Status}");

            Console.WriteLine($"Reservations for guest: {guest.Reservations.Count}");
            Console.WriteLine($"Reservations for room: {room.Reservations.Count}");
        }
    }
}
