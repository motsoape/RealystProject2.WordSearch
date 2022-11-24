using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Services.Interfaces
{
    public interface IWordIteratorService
    {
        void ClearSearch(ref char[,,] grid);
        bool Search(ref char[,,] grid, int width, int height, ref string word, int wordIndex);
    }
}
