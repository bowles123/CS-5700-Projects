using System.Collections;
using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public abstract class Component: Observer, IEnumerable
    {
        public int Id { get; private set; }
        public List<Cell> Cells { get; private set; }

        public Component(int id)
        {
            Id = id;
            Cells = new List<Cell>();
        }

        internal Component(int id, List<Cell> cells)
        {
            Id = id;
            Cells = cells;
        }

        public override string ToString()
        {
            string component = "";
            foreach (Cell cell in Cells)
                component += (cell.Value + " ");
            return component;
        }

        public void Update(Subject cell)
        {
            Cell c = cell as Cell;

            foreach (Cell _cell in Cells)
                _cell.RemovePossibility(c.Value);
        }

        public bool ContainsPossibility(char value, int x, int y)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.X == x && cell.Y == y) continue;

                if (cell.Possibilities.Contains(value))
                    return true;
            }
            return false;
        }

        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Cells.Count; i++)
                yield return Cells[i];
        }
    }
}
