﻿namespace AlkemyWallet.Core.Models.DTO.UserLogin;

public class RefreshTokenDTO
{
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.Now >= Expires;
    public DateTime Created { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string RevokedByIp { get; set; }
    public string ReplacedByToken { get; set; }
    public bool IsActive => Revoked is not null && !IsExpired;
}