namespace Task8;
public class Runner(IFileManager fileManager)
{
    private readonly IFileManager _fileManager = fileManager;

    public void SyncMethod()
    {
        for (var i = 0; i < 100; i++)
        {
            var fileName = $"task8_{i}.txt";
            _fileManager.Write(fileName, i.ToString());
            _fileManager.Delete(fileName);
        }
    }

    public async Task AsyncMethod()
    {

        var addTasks = new List<Task>();
        var deleteTasks = new List<Task>();

        for (var i = 1; i < 100; i++)
        {
            var fileName = $"task8_{i}.txt";

            addTasks.Add(_fileManager.WriteAsync(fileName, i.ToString()));
        }
        await Task.WhenAll(addTasks);

        for (var i = 1; i < 100; i++)
        {
            var fileName = $"task8_{i}.txt";

            deleteTasks.Add(_fileManager.DeleteAsync(fileName));
        }
        await Task.WhenAll(deleteTasks);
    }
}
