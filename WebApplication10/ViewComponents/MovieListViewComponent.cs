using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Repositories;

namespace WebApplication10.ViewComponents;

public class MovieListViewComponent : ViewComponent
{
    private readonly MovieRepository _movieRepository;

    public MovieListViewComponent(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(
        [DataType(DataType.Date)]
        DateTime? date = null)
    {
        date ??= DateTime.Today;
        var movies = await _movieRepository
            .GetMovies(date.Value);
        return View("~/Views/Components/MovieListComponent.cshtml", movies);
    }
}
