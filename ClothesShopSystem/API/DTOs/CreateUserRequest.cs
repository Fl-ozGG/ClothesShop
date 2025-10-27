using System.ComponentModel;
using ClothesShopSystem.Domain.Enums;

namespace ClothesShopSystem.API.DTOs;

public class CreateUserRequest
{
    [DefaultValue("Anon")]
    public string Name { get; set; }

    [DefaultValue("anon@email.com")]
    public string Email { get; set; }
    
    [DefaultValue("1996-08-12")]
    public string BornYear { get; set; }
    
    [DefaultValue("AnonStreet 134")]
    public string Address { get; set; }
    [DefaultValue("AnonCity")]
    public string City { get; set; }
    [DefaultValue("+34666666666")]
    public string PhoneNumber { get; set; }
    
    public UserTypeEnum UserType  { get; set; }
}