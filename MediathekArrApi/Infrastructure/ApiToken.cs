﻿using System.ComponentModel.DataAnnotations;

namespace MediathekArrApi.Infrastructure;

public class ApiToken
{
    [Key]
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
}
