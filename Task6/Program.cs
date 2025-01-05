using System.Text.RegularExpressions;

Console.WriteLine("Input a number: ");
var input = Console.ReadLine();

if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Input cannot be null or empty.");
    return;
}

if (Regex.IsMatch(input, @"^\d+$"))
{
    var number = int.Parse(input);
    var bin = Convert.ToString(number, 2);
    Console.WriteLine($"Number in binary {number}: {bin}");
}
else
{
    Console.WriteLine("Incorrect number");
}

if (Regex.IsMatch(input, @"^[02468]$|^\d*[02468]$"))
{
    Console.WriteLine("Number divisible by 2");
}
else
{
    Console.WriteLine("Number not divisible by 2");
}
