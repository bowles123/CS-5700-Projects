using AppLayer.SudokuComponents;
using System.Diagnostics;

namespace AppLayer.SolvingAlgorithms
{
    public abstract class SolvingAlgorithm
    {
        private Stopwatch stopwatch;
        private int solveTime;
        protected string actualType;

        public Puzzle Puzzle { get; set; }
        public abstract bool CheckCell(Cell c);

        public SolvingAlgorithm()
        {
            stopwatch = new Stopwatch();
        }

        public bool Execute()
        {
            bool updated = false;
            Start();

            foreach (Cell cell in Puzzle)
            {
                if (cell.Value.Equals('_'))
                {
                    updated = CheckCell(cell);
                }
            }

            if (Puzzle.BacktrackingStack.Count == 0 && !updated && actualType.Equals("SOLVED"))
                Puzzle.Solved = true;

            End();
            return updated;
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void End()
        {
            stopwatch.Stop();
            solveTime = stopwatch.Elapsed.Seconds;

            if (Puzzle.Solved)
                Puzzle.WriteOutPuzzle(Puzzle.OutFile);
        }

        public void UpdateCell(Cell cell, char val)
        {
            cell.Update(val);
        }
    }
}
