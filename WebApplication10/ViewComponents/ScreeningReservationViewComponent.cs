using Microsoft.AspNetCore.Mvc;
using WebApplication10.Repositories;
using WebApplication6.Models;

namespace WebApplication10.ViewComponents;

public class ScreeningReservationViewComponent : ViewComponent
{
    private readonly ScreeningRepository _screeningRepository;

    public ScreeningReservationViewComponent(ScreeningRepository screeningRepository)
    {
        _screeningRepository = screeningRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(long id)
    {
        var screening = await _screeningRepository.GetScreeningById(id);
        return View("~/Views/Components/ScreeningReservationComponent.cshtml", screening);
    }
}