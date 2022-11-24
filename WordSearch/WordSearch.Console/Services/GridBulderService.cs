using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Services.Interfaces;

namespace WordSearch.Services
{
    public class GridBulderService : IGridBulderService
    {
        public char[,,] grid { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public GridBulderService(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public char[,,] Build()
        {
            int z = 2;
            grid = new char[x, y, z];
            Random rnd = new Random();

            for (int _x=0; _x < x; _x++)
            {
                for(int _y=0; _y < y; _y++)
                {
                    int ascii_index = rnd.Next(65, 91);
                    grid[_x, _y, 0] = Convert.ToChar(ascii_index);
                    grid[_x, _y, 1] = '#';
                }
            }

            return grid;
        }
    }
}
