using WordSearch.Services;
using WordSearch.Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        int width = 8;
        int height = 8;
        IGridBulderService gridBuilder = new GridBulderService(width, height);
        IWordIteratorService interator = new WordIteratorService();

        string word = "MPHAHLELE";
        var grid = gridBuilder.Build();
        var oldGrid = grid;

        var results = interator.Search(ref grid, width, height, ref word, 0);

        if (!results)
        {
            grid = oldGrid;
            Console.WriteLine(@"{0} - Not Found", word);

        }
        else
        {
            Console.WriteLine(@"{0} - Found", word);
        }
        Console.WriteLine();

        //Print Grid

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(grid[x, y, 1] == '*')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(grid[x, y, 0]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(grid[x, y, 0]);
                }
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("*****************************************************");
    }
}