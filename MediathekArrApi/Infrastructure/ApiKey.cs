using System.ComponentModel.DataAnnotations;

namespace MediathekArrApi.Infrastructure;

public class ApiKey
{
    [Key]
    public int Id { get; set; }
    public string Key { get; set; }
}
