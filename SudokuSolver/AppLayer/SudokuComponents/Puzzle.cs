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
        }

        public bool Solve(List<SolvingAlgorithm> algorithms)
        {
            bool changed = true;

            while (changed)
            {
                changed = TryTechniques(algorithms);
                if (changed && Invalid) return false;
            }

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

            foreach (Row row in Rows)
            {
                foreach (Cell cell in row.Cells)
                    writer.Write(cell.Value + " ");
                writer.Write("\n");
            }
            writer.Close();
        }

        public override string ToString()
        {
            string puzzle = "";

            foreach (Row row in Rows)
                puzzle += (row + "\n");
            return puzzle;
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

        // Not subscribing to the correct components? Possibilities are being updated, but cells are not.
        public Puzzle Clone()
        {
            Puzzle puzzle = MemberwiseClone() as Puzzle;
            List<Row> rows = new List<Row>();
            List<Column> columns = new List<Column>();
            List<Block> blocks = new List<Block>();
            Stack<Puzzle> stack = new Stack<Puzzle>();

            foreach (Row row in Rows)
            {
                List<Cell> cells = new List<Cell>();
                Row r = new Row(row.Id);

                foreach (Cell cell in row)
                {
                    Cell _cell = cell.CloneCell();
                    _cell.Subscribe(row);
                    r.Cells.Add(_cell);
                }

                rows.Add(r);
            }

            foreach (Column column in Columns)
            {
                List<Cell> cells = new List<Cell>();
                Column c = new Column(column.Id);

                foreach (Cell cell in column)
                {
                    Cell _cell = cell.CloneCell();
                    _cell.Subscribe(column);
                    c.Cells.Add(_cell);
                }

                columns.Add(c);
            }

            foreach (Block block in Blocks)
            {
                List<Cell> cells = new List<Cell>();
                Block b = new Block(block.Id);

                foreach (Cell cell in block)
                {
                    Cell _cell = cell.CloneCell();
                    _cell.Subscribe(block);
                    b.Cells.Add(_cell);
                }

                blocks.Add(b);
            }

            puzzle.Rows = rows;
            puzzle.Columns = columns;
            puzzle.Blocks = blocks;
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
