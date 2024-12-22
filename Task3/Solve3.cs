namespace Task3;

public static class Solve3
{
    public static void Run()
    {
        var students = new List<Student>
        {
            new () { FirstName = "Evgenii", LastName = "Chumak", Score = 85 },
            new () { FirstName = "Mariia", LastName = "Davidchenko", Score = 92 },
            new () { FirstName = "Petro", LastName = "Sidorov", Score = 78 }
        };

        var MaxScore = students.Max(s => s.Score);
        var topStudent = students.First(s => s.Score == MaxScore);
        Console.WriteLine($"Student with max score: {topStudent.FirstName} {topStudent.LastName}, {topStudent.Score}");
    }
}