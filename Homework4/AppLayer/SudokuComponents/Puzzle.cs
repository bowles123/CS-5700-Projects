using System.Collections.Generic;
using AppLayer.SolvingAlgorithms;
using System.IO;
using System.Collections;

namespace AppLayer.SudokuComponents
{
    public class Puzzle : IEnumerable
    {
        public SolvingAlgorithm SolvingAlgorithm { get; set; }
        public List<Row> Rows { get; private set; }
        public List<Column> Columns { get; private set; }
        public List<Block> Blocks { get; private set; }
        public List<char> Symbols { get; private set; }
        public bool Solved { get; set; }
        public string OutFile { get; set; }

        internal Puzzle(List<Row> r, List<Column> c, List<Block> b, List<char> s)
        {
            Rows = r;
            Columns = c;
            Blocks = b;
            Symbols = s;
            SolvingAlgorithm = new SolvedPuzzle();
            SolvingAlgorithm.Puzzle = this;
        }

        public void Solve()
        {
            SolvingAlgorithm.Start();
        }

        public void WriteOutPuzzle(string file)
        {
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(Rows.Count);
            
            foreach(char symbol in Symbols)
                writer.Write(symbol);
            writer.Write("\n");

            foreach (Row row in Rows)
            {
                foreach (Cell cell in row.Cells)
                    writer.Write(cell.Value);
                writer.Write("\n");
            }
        }

        public void FillPossibilities()
        {
            foreach (Row row in Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    if (cell.Value.Equals('_'))
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
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Rows.Count; i++)
                for (int j = 0; j < Rows[i].Cells.Count; j++)
                    yield return Rows[i].Cells[j];
        }
    }
}
