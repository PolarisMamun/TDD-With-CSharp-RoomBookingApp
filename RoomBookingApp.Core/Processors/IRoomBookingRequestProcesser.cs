using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public interface IRoomBookingRequestProcesser
    {
        RoomBookingResult BookRoom(RoomBookingRequest bookingRequest);
    }
}