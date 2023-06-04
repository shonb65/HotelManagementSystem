namespace HotelManagemnt.ReservationServiceContracts
{
    public record ReservationCreated(Guid id, Guid roomId, string roomStatus);

    public record ReservationUpdated(Guid id, Guid roomId, string roomStatus);

}