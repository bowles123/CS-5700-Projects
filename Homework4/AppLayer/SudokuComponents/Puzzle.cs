using System.Collections.Generic;
using AppLayer.SolvingAlgorithms;
using System.IO;
using System.Collections;
using System.Linq;

namespace AppLayer.SudokuComponents
{
    public class Puzzle : IEnumerable
    {
        public int Solutions { get; set; }
        public int Blanks { get; internal set; }
        public Stack<Puzzle> BacktrackingStack { get; private set; }
        public List<Row> Rows { get; private set; }
        public List<Column> Columns { get; private set; }
        public List<Block> Blocks { get; private set; }
        public List<char> Symbols { get; private set; }
        public bool Solved { get { return Blanks == 0; }}
        public bool Invalid { get; set; }
        public string OutFile { get; set; }

        public Puzzle(List<Row> r, List<Column> c, List<Block> b, List<char> s)
        {
            Rows = r;
            Columns = c;
            Blocks = b;
            Symbols = s;
            Invalid = false;
            Solutions = 0;
            Blanks = 0;
            BacktrackingStack = new Stack<Puzzle>();
        }

        public bool Solve(List<SolvingAlgorithm> algorithms)
        {
            bool changed = true;

            while (changed)
                changed = TryTechniques(algorithms);

            if (Solved)
            {
                Solutions++;
                return true;
            }

            return false;
        }

        private bool TryTechniques(List<SolvingAlgorithm> techniques)
        {
            return techniques.Any(s => s.Execute());
        }

        public void WriteOutPuzzle()
        {
            StreamWriter writer = new StreamWriter(OutFile);
            writer.WriteLine(Rows.Count);
            
            foreach(char symbol in Symbols)
                writer.Write(symbol + " ");
            writer.Write("\n");

            foreach (Row row in Rows)
            {
                foreach (Cell cell in row.Cells)
                    writer.Write(cell.Value + " ");
                writer.Write("\n");
            }
            writer.Close();
        }

        public void FillPossibilities()
        {
            foreach (Row row in Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.Value.Equals('-'))
                    {
                        List<char> possibilities = new List<char>();

                        foreach (char symbol in Symbols)
                            possibilities.Add(symbol);

                        foreach (Cell c in row)
                            if (possibilities.Contains(c.Value))
                                possibilities.Remove(c.Value);

                        foreach (Cell c in Columns[cell.X - 1])
                            if (possibilities.Contains(c.Value))
                                possibilities.Remove(c.Value);

                        foreach (Cell c in Blocks[cell.B - 1])
                            if (possibilities.Contains(c.Value))
                                possibilities.Remove(c.Value);

                        cell.AddPossibilities(possibilities);
                        Blanks++;
                    }
                }
            }
        }

        public Puzzle Clone()
        {
            Puzzle puzzle = MemberwiseClone() as Puzzle;
            Stack<Puzzle> stack = new Stack<Puzzle>();

            foreach (Puzzle p in BacktrackingStack)
            {
                stack.Push(p);
            }
            BacktrackingStack = stack;

            foreach (Cell cell in this)
            {
                cell.Subscribe(puzzle.Rows[cell.Y - 1]);
                cell.Subscribe(puzzle.Columns[cell.X - 1]);
                cell.Subscribe(puzzle.Blocks[cell.B - 1]);
            }

            return puzzle;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Rows.Count; i++)
                for (int j = 0; j < Rows[i].Cells.Count; j++)
                    yield return Rows[i].Cells[j];
        }
    }
}
