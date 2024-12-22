namespace Task3;

public static class Solve5
{
    public static void Run()
    {
        var employers = new List<Employee>
        {
            new() { Name = "Mariia", LastName = "Davidchenko", DateOfBirth = new DateTime(2004, 7, 2), EmploymentDate = new DateTime (2021, 10, 6) },
            new() { Name = "Oleksandr", LastName = "Popov", DateOfBirth = new DateTime(2000, 11, 25), EmploymentDate = new DateTime(2017, 12, 12) },
            new() { Name = "Daria", LastName = "Tanska", DateOfBirth = new DateTime(2001, 9, 14), EmploymentDate =  new DateTime(2024, 5, 21) },
            new() { Name = "Maksym", LastName = "Brozenko", DateOfBirth = new DateTime(2000, 12, 20), EmploymentDate = new DateTime(2018, 7, 4) }
        };

        var currentDate = DateTime.Now;

        var fiveyearEmployees = employers
        .Where(e => (currentDate - e.EmploymentDate).TotalDays / 365 > 5);

        foreach (var employer in fiveyearEmployees)
        {
            Console.WriteLine($"Name: {employer.Name} {employer.LastName}");
            Console.WriteLine($"Date of Employment: {employer.EmploymentDate:yyyy-MM-dd}");
            Console.WriteLine($"Date of Birth: {employer.DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine();
        }
    }
}