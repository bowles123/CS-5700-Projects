using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Cell: Subject
    {
        private List<char> possibilities = new List<char>();
        private int x;
        private int y;

        public List<char> Possibilities { get { return possibilities; } }
        public char Value { get; private set; }
        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Cell(char symbol, int row, int col)
        {
            Value = symbol;
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
