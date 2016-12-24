namespace AppLayer.SudokuComponents
{
    public class Originator
    {
        private Puzzle state;

        public Originator(Puzzle p)
        {
            state = p;
        }

        public Memento SaveToMemento()
        {
            return new Memento(state);
        }

        public void ResetFromMemento(Memento m)
        {
            state = m.State;
        }
    }
}
