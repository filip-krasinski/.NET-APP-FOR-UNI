using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.Repositories;

namespace WebApplication10.Controllers;

public class HomeController : Controller
{

    private readonly MovieRepository _movieRepository;
    private readonly ScreeningRepository _screeningRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(
        MovieRepository movieRepository,
        ScreeningRepository screeningRepository,
        UserManager<IdentityUser> userManager
    )
    {
        _userManager = userManager;
        _movieRepository = movieRepository;
        _screeningRepository = screeningRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> ReserveSeats(ReserveSeatsRequest request)
    {
        var id = User.Claims
            .FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)
            ?.Value;
        
        var user = await _userManager.FindByIdAsync(id);
        var reservation = await _screeningRepository.CreateReservation(request, user);
        return Json(null);
    }

    public IActionResult Index(DateTime? date = null)
    {
        date ??= DateTime.Today.AddDays(1);
        return View(date.Value);
    }
    
    public async Task<IActionResult> MovieList(
        [DataType(DataType.Date)]
        DateTime? date = null)
    {
        date ??= DateTime.Today;
        var movies = await _movieRepository
            .GetMovies(date.Value);
        return PartialView("~/Views/Components/MovieListComponent.cshtml", movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult ScreeningReservation()
    {
        return View();
    }
    
    public IActionResult Reservations()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}