using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Cell: Subject
    {
        private List<char> possibilities = new List<char>();
        private int x;
        private int y;
        private int b;

        public List<char> Possibilities { get { return possibilities; } }
        public char Value { get; private set; }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int B { get { return b; } }

        public Cell(char symbol, int row, int col, int block)
        {
            Value = symbol;
            b = block;
            x = col;
            y = row;
        }

        public void Update(char val, List<char> poss)
        {
            Value = val;
            possibilities = poss;
        }
    }
}
