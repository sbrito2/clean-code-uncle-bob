class Program
{
    static int[,] _grid = new int[15, 15];

    static void Main()
    {
        // Initialize some elements in 2D array.
        _grid[0, 1] = 4;
        _grid[4, 4] = 5;
        _grid[14, 2] = 3;

        // Sum values in 2D array.
        int sum = 0;
        foreach (int value in GridValues())
        {
            sum += value;
        }
        // Write result.
        Console.WriteLine("SUMMED 2D ELEMENTS: " + sum);
    }

    public static IEnumerable<int> GridValues()
    {
        // Use yield return to return all 2D array elements.
        for (int x = 0; x < 15; x++)
        {
            for (int y = 0; y < 15; y++)
            {
                yield return _grid[x, y];
            }
        }
    }
}