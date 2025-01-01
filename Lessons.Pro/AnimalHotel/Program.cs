// create abstract factory to create animals
using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;

var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" };
var ages = new int[] { 3, 14, 7, 2 };
var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };
var ownerAges = new int[] { 26, 29, 43, 50 };
var colorAnimal = new string[] { "Brown", "White", "Black", "Green" };

IAnimalFactory animalFactory = new AnimalFactory();
animalFactory.Registrator("Parrot", (name, owner, age, color) => new Parrot(name, owner, age, color));
animalFactory.Registrator("Horse", (name, owner, age, color) => new Horse(name, owner, age, color));

var random = new Random();

var genericHotel = new GenericHotel<IAnimal>();
var kyivHotel = new KyivHotel();
var romashkaHotel = new RomashkaHotel();

for (int i = 0; i < 10; i++)
{
    var animalName = animalNames[random.Next(animalNames.Length)];
    var ownerName = ownerNames[random.Next(ownerNames.Length)];
    var ownerAge = ownerAges[random.Next(ownerAges.Length)];
    var animalAge = ages[random.Next(ages.Length)];
    var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
    var color = colorAnimal[random.Next(colorAnimal.Length)];

    var owner = new Owner(ownerName, ownerPhoneNumber, ownerAge);
    
    IAnimal animal = animalFactory.CreateAnimal(animalName, animalName, owner, animalAge, color);

    genericHotel.AddAnimal(animal);
    kyivHotel.AddAnimal(animal);
    romashkaHotel.AddAnimal(animal);
}

    /*IAnimal oldSchool = default;
    
    switch (animalType)
    {
        case 0:
            break;
        case 1:
            oldSchool = animalFactory.CreateCat(animalName, owner);
            break;
        default:
            throw new ArgumentException("Invalid animal type");
            break;
    }*/

foreach (var animal in genericHotel)
{
    Console.WriteLine(animal.Name);
    animal.Eat();
}

foreach (var animal in kyivHotel)
{
    Console.WriteLine(animal.Name);
    animal.Sleep();
}

foreach (var animal in romashkaHotel)
{
    Console.WriteLine((animal as IAnimal)?.Name ?? "Animal is not of type IAnimal.");
}

Console.WriteLine("\nEnter owner's name to filter animals:");
var inputOwnerName = Console.ReadLine();
inputOwnerName ??= "Unknown";

void FilteredAnimals(string hotelName, IEnumerable<IAnimal> hotel, string ownerName)
{
    Console.WriteLine($"\nAnimals in {hotelName} owned by {ownerName}:");
    var filteredAnimals = Animal.FilterByOwnerName(hotel.Cast<Animal>(), ownerName);
    foreach (var animal in filteredAnimals)
    {
        Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Owner: {animal.Owner.Name}, Owner Age: {animal.Owner.OwnerAge}");
    }
}

FilteredAnimals("Generic Hotel", genericHotel, inputOwnerName);
FilteredAnimals("Kyiv Hotel", kyivHotel, inputOwnerName);
FilteredAnimals("Romashka Hotel", romashkaHotel, inputOwnerName);

// TODO: get all animals with name 'Parrot' from genericHotel
var genericHotelParrots = genericHotel.Where(x => x.Name == "Parrot");
Console.WriteLine("\nParrots in GenericHotel:");
foreach (var parrot in genericHotelParrots)
{
    Console.WriteLine($"{parrot.Name}, Age: {parrot.Age}, Owner: {parrot.Owner.Name}");
}

// TODO: get all animals with name 'Parrot' from kyivHotel
var kyivHotelParrots = kyivHotel.Where(x => x.Name == "Parrot");
Console.WriteLine("\nParrots in KyivHotel: ");
foreach (var parrot in kyivHotel)
{
    Console.WriteLine($"{parrot.Name}, Age: {parrot.Age}, Owner: {parrot.Owner.Name}");
}

// TODO: get all animals with name 'Parrot' from romashkaHotel
var romashkaHotelParrots = romashkaHotel.OfType<Cat>();
Console.WriteLine("\nParrots in RomashkaHotel: ");
foreach (var parrot in romashkaHotel)
{
    Console.WriteLine($"{parrot.Name}, Age: {parrot.Age}, Owner: {parrot.Owner.Name}");
}

// TODO: extend animals entity to have a property 'Age' and sort animals by age
var genericHotelAnimals = genericHotel.OrderBy(x => x.Age);
Console.WriteLine("\nSorted animals by age in GenericHotel: ");
foreach (var animal in genericHotelAnimals)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Owner: {animal.Owner.Name}");
}

var kyivHotelAnimals = kyivHotel.OrderBy(y => y.Age);
Console.WriteLine("\nSorted animals by age in KyivHotel: ");
foreach (var animal in kyivHotelAnimals)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Owner: {animal.Owner.Name}");
}

var romashkaHotelAnimals = romashkaHotel.OrderBy(z => z.Age);
Console.WriteLine("\nSorted animals by age in RomashkaHotel: ");
foreach (var animal in romashkaHotelAnimals)
{
    Console.WriteLine($"{animal.Name}, Age: {animal.Age}, Owner: {animal.Owner.Name}");
}
