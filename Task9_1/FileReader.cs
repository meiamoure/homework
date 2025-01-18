namespace Task9_1;
internal class FileReader : IFileReader
{
    public List<int> ReadNumbers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return [];
        }

        return File.ReadAllLines(filePath)
                .Where(line => int.TryParse(line, out _))
                .Select(int.Parse)
                .ToList();
    }
}
