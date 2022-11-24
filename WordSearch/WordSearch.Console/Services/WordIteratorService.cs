using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Services.Interfaces;

namespace WordSearch.Services
{
    public class WordIteratorService : IWordIteratorService
    {
        public WordIteratorService() { }

        public bool Search(ref char[,,] grid, int width, int height, ref string word, int wordIndex)
        {
            if (word == null)
                return false;
            if (wordIndex >= word.Length)
                return true;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (grid[x, y, 0] == word[wordIndex] && grid[x, y, 1] == '#')
                    {
                        grid[x, y, 1] = '*';
                        return Search(ref grid, width, height, ref word, ++wordIndex);
                    }
                }
            }

            return false;
        }
    }
}
