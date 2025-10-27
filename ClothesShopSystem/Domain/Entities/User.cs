using ClothesShopSystem.Domain;
using ClothesShopSystem.Domain.Enums;

public class User
{
    public Guid Id {get; init;}
    public string Name {get; set;}
    public string Email {get; set;}
    public string BornYear {get; set;}
    public string PhoneNumber {get; set;}
    public string Address {get; set;}
    public string City {get; set;}
    public UserTypeEnum UserType{get; set;}
    public User(string name, string email, string bornYear, string address, string city, string phoneNumber, UserTypeEnum userType)
    {
        Name = name;
        Email = email; 
        BornYear = bornYear;
        Address = address;
        City = city;
        PhoneNumber = phoneNumber;
        UserType = userType;
    }
}