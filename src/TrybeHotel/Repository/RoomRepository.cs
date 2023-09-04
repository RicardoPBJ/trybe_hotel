using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            return _context.Rooms.Select(room => new RoomDto
            {
                roomId = room.RoomId,
                name = room.Name,
                capacity = room.Capacity,
                image = room.Image,
                hotel = new HotelDto
                {
                    hotelId = room.Hotel!.HotelId,
                    name = room.Hotel.Name,
                    address = room.Hotel.Address,
                    cityId = room.Hotel.City!.CityId,
                    cityName = room.Hotel.City!.Name,
                }
            }).ToList();
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return _context.Rooms.Select(room => new RoomDto
            {
                roomId = room.RoomId,
                name = room.Name,
                capacity = room.Capacity,
                image = room.Image,
                hotel = new HotelDto
                {
                    hotelId = room.Hotel!.HotelId,
                    name = room.Hotel.Name,
                    address = room.Hotel.Address,
                    cityId = room.Hotel.City!.CityId,
                    cityName = room.Hotel.City!.Name,
                }
            }).Last();
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId) {
            var RoomDelete = _context.Rooms.FirstOrDefault(room => room.RoomId == RoomId);

            _context.Rooms.Remove(RoomDelete!);
        }
    }
}