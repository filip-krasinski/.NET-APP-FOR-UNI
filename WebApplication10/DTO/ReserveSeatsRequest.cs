namespace WebApplication10.DTO;


public class ReserveSeatsRequest
{
    public int ScreeningId { get; set; }
    public List<long> Seats { get; set; }
}