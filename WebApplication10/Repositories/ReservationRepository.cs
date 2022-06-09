using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;
using WebApplication6.Models;

namespace WebApplication10.Repositories;

public class ReservationRepository
{
    
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<Reservation>> GetUserReservations(string userId)
    {
        return await _context.Reservations
            .Where(x => x.ReservedBy.Id == userId)
            .Include(r => r.Screening)
                .ThenInclude(s => s.Movie)
            .Include(s => s.Seats)
            .ToListAsync();
    }
}