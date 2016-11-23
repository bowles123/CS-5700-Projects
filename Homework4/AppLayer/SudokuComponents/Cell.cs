using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class Cell: Subject
    {
        public List<char> Possibilities { get; private set; }
        public char Value { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int B { get; private set; }

        public Cell(char symbol, int row, int col, int block)
        {
            Possibilities = new List<char>();
            Value = symbol;
            B = block;
            X = col;
            Y = row;
        }

        public void Update(char val)
        {
            Value = val;
            Possibilities = new List<char>();
            NotifyObservers();
        }

        public void RemovePossibility(char poss)
        {
            Possibilities.Remove(poss);
            //NotifyObservers(); // Being called over and over again for some reason.
        }

        public void AddPossibilities(List<char> possibilities)
        {
            foreach (char possibility in possibilities)
                Possibilities.Add(possibility);
            NotifyObservers();
        }
    }
}
