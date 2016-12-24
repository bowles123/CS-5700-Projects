namespace AppLayer.SudokuComponents
{
    public class Memento
    {
        public Puzzle State { get; private set; }

        public Memento(Puzzle state)
        {
            State = state;
        }
    }
}
