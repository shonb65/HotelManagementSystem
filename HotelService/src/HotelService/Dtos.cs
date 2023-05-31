namespace HotelManagemnt.HotelService.Dtos
{
    public record HotelDto(Guid id, string hotelName)

    public record RoomDto(Guid id, int roonNumer, string roomStatus);
}