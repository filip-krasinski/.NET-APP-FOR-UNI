using Microsoft.AspNetCore.Mvc;
using WebApplication10.Repositories;
using Microsoft.AspNetCore.Identity;

namespace WebApplication10.ViewComponents;

public class ReservationsViewComponent : ViewComponent
{
    private readonly ReservationRepository _reservationRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public ReservationsViewComponent(
        ReservationRepository reservationRepository,
        UserManager<IdentityUser> userManager
    )
    {
        _userManager = userManager;
        _reservationRepository = reservationRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userId)
    {
        var reservations = await _reservationRepository.GetUserReservations(userId);
        return View("~/Views/Components/ReservationsComponent.cshtml", reservations);
    }
}