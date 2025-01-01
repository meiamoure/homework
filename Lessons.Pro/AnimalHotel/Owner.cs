namespace AnimalHotel;

public class Owner(string name, string phoneNumber, int ownerAge)
{
    public string Name { get; set; } = name;

    public string PhoneNumber { get; set; } = phoneNumber;

    public int OwnerAge { get; set; } = ownerAge;
}