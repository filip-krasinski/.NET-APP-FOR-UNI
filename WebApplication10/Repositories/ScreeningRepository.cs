using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;
using WebApplication10.DTO;
using WebApplication6.Models;

namespace WebApplication10.Repositories;

public class ScreeningRepository
{
    private readonly ApplicationDbContext _context;

    public ScreeningRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Screening> GetScreeningById(long id)
    {
        return await _context.Screenings
            .Include(s => s.Movie)
            .Include(s => s.Reservations)
                .ThenInclude(r => r.Seats)
            .Include(s => s.CinemaHall)
                .ThenInclude(c => c.Seats)
            .FirstAsync(s => s.Id == id);
    }

    public async Task<Reservation> CreateReservation(ReserveSeatsRequest request, IdentityUser user)
    {
        var screening = await _context.Screenings
            .FirstAsync(s => s.Id == request.ScreeningId);
        
        var seats = await _context.Seats
            .Where(s => request.Seats.Contains(s.Id))
            .ToListAsync();

        var reservation = new Reservation
        {
            ReservedAt = DateTime.Now,
            ReservedBy = user,
            Screening = screening,
            Seats = seats
        };

        await _context.AddAsync(reservation);
        await _context.SaveChangesAsync();
        return reservation;
    }

}