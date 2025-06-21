// ReservationDtos.cs
public record ReservationDto(int Id, int UserId, int RestaurantId, DateTime ReservationDate, int NumberOfGuests, ReservationStatus Status);
public record CreateReservationDto(int UserId, int RestaurantId, DateTime ReservationDate, int NumberOfGuests);