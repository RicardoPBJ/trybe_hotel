using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
            return _context.Hotels.Select(hotel => new HotelDto
            {
                hotelId = hotel.HotelId,
                name = hotel.Name,
                address = hotel.Address,
                cityId = hotel.CityId,
                cityName = hotel.City!.Name,
            }).ToList();
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            return _context.Hotels.Select(hotel => new HotelDto
            {
                hotelId = hotel.HotelId,
                name = hotel.Name,
                address = hotel.Address,
                cityId = hotel.CityId,
                cityName = hotel.City!.Name,
            }).Last();
        }
    }
}