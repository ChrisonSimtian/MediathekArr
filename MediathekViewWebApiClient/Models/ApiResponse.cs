namespace MediathekViewWeb.Models;

public class ApiResponse
{
    public Result Result { get; set; }
    public string Err { get; set; } // Error message, if any
}
