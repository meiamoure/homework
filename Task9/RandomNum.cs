namespace Task9;
public class RandomNum
{
    private readonly Random _random = new Random();

    public List<int> Randomer()
    {
        var count = _random.Next(2, 21);
        var numbers = new List<int>();

        for (var i = 0; i < count; i++)
        {
            var number = _random.Next(1, 100);
            numbers.Add(number);
        }
        return numbers;
    }
}
