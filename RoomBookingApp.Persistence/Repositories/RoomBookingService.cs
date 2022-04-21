using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Persistence.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDbContext _context;

        public RoomBookingService(RoomBookingAppDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            /*var unAvailableRooms = _context.RoomBookings.Where(q => q.Date == date).Select(q => q.Room).ToList();

            var availableRooms = _context.Rooms.Where(q => unAvailableRooms.Contains(q.Id) == false).ToList();*/

            var availableRooms = _context.Rooms.Where(q => !q.RoomBooking.Any(x=> x.Date == date)).ToList();

            return availableRooms;
        }

        public void Save(RoomBooking roomBooking)
        {
            _context.Add(roomBooking);
            _context.SaveChanges();
        }
    }
}
