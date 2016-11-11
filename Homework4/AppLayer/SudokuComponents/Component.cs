using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public abstract class Component: Observer
    {
        protected List<Cell> cells = new List<Cell>();

        public int Id { get; protected set; }
        public string ActualType { get; protected set; }
        public List<Cell> Cells { get { return cells; } }

        public Component(int id) { Id = id; }
        public abstract void Update(Subject cell);

        public void AddCell(Cell cell)
        {
            cells.Add(cell);
        }
    }
}
