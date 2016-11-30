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
                if (cell.Value.Equals('-'))
                {
                    updated = CheckCell(cell);

                    if (updated)
                        break;
                }
            }

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
        }

        public void UpdateCell(Cell cell, char val)
        {
            cell.Update(val);
        }
    }
}
