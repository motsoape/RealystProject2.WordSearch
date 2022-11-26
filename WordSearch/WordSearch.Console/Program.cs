using WordSearch.Services;
using WordSearch.Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        int width = 5;
        int height = 5;
        string textFile;
        IGridBulderService gridBuilder = new GridBulderService(width, height);
        IWordIteratorService interator = new WordIteratorService();
        var grid = gridBuilder.Build();

        Console.WriteLine("******************Word Search***************");
        Console.WriteLine("********************************************");
        Console.Write("Enter file path or press enter to exit: ");
        textFile = Console.ReadLine();

        if (!string.IsNullOrEmpty(textFile) && !string.IsNullOrWhiteSpace(textFile))
        {
            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    string word;

                    while ((word = file.ReadLine()) != null)
                    {
                        word = word.ToUpper();
                        var results = interator.Search(ref grid, width, height, ref word, 0);

                        if (!results)
                        {
                            interator.ClearSearch(ref grid);
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
                                if (grid[x, y, 1] == '*')
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
                        interator.ClearSearch(ref grid);
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exists.");
            }
        }
    }
}