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

        /*
         * Search words on the grid
         */
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

        /*
         * Clear the grid for found words positions
         */
        public void ClearSearch(ref char[,,] grid)
        {
            if (grid != null)
            {
                for (int _x = 0; _x < grid.GetLength(0); _x++)
                {
                    for (int _y = 0; _y < grid.GetLength(1); _y++)
                    {
                        grid[_x, _y, 1] = '#';
                    }
                }
            }
        }
    }
}
