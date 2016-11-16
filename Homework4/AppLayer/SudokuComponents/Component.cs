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

        public void Update(Subject cell)
        {
            Cell c = cell as Cell;

            foreach (Cell _cell in Cells)
                _cell.RemovePossibility(c.Value);
        }

        public bool Contains(char value)
        {
            foreach (Cell cell in Cells)
                if (cell.Possibilities.Contains(value))
                    return true;
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
