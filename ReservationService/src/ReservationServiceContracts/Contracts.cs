namespace HotelManagemnt.ReservationServiceContracts
{
    public record ReservationCreated(Guid id, int roomId, string roomStatus);

    public record ReservationUpdated(Guid id, int roomId, string roomStatus);

}