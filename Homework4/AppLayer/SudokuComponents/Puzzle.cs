using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Puzzle
    {
        private List<Row> rows;
        private List<Column> columns;
        private List<Block> blocks;
        private List<char> symbols;

        public List<Row> Rows { get { return rows; } }
        public List<Column> Columns { get { return columns; } }
        public List<Block> Blocks { get { return blocks; } }
        public List<char> Symbols { get { return symbols; } }

        internal Puzzle(List<Row> r, List<Column> c, List<Block> b, List<char> s)
        {
            rows = r;
            columns = c;
            blocks = b;
            symbols = s;
        }

        public void Solve()
        {

        }

        public void WriteOutPuzzle()
        {

        }
    }
}
