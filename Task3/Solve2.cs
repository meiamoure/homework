namespace Task3;

public static class Solve2
{
    public static void Run()
    {
        int[] nums1 = [1, 2, 3, 4, 5, 6, 7];
        int[] nums2 = [3, 5, 8, 56, 2, 0];

        var result = nums1.Concat(nums2).ToArray();

        Console.WriteLine(string.Join(", ", result));
    }
}