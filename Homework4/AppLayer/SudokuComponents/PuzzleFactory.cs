using System.IO;
using System;
using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class PuzzleFactory
    {
        public Puzzle Create(string file)
        {
            if (!File.Exists(file)) return null;

            List<Row> rows;
            Puzzle puzzle = null;
            StreamReader reader = new StreamReader(file);
            List<char> possibleSymbols = new List<char>();
            int size = Convert.ToInt32(reader.ReadLine());
            string symbols = reader.ReadLine();

            foreach (char symbol in symbols)
                if (symbol != ' ')
                    possibleSymbols.Add(symbol);

            if (possibleSymbols.Count != size)
                throw new Exception("Not enough symbols given.");
            rows = CreateRows(ref reader, size);

            if (possibleSymbols.Count != rows.Count)
                throw new Exception("Non-symmetric puzzle.");

            puzzle = new Puzzle(rows, CreateColumns(rows), CreateBlocks(rows), possibleSymbols);
            puzzle.OutFile = file.Insert(file.Length - 4, "-Out");
            puzzle.FillPossibilities();
            return puzzle;
        }

        public List<Row> CreateRows(ref StreamReader reader, int size)
        {
            int b, c, r = 1, n = Convert.ToInt32(Math.Sqrt(size));
            List<Row> rows = new List<Row>();

            while (!reader.EndOfStream)
            {
                Row row = new Row(r);
                Cell cell;
                string values = reader.ReadLine();
                c = 1;

                if (values == "") break;

                foreach (char symbol in values)
                {
                    if (symbol != ' ')
                    {
                        b = ((r - 1) / n) * n + (c - 1) / n;
                        cell = new Cell(symbol, r, c++, b + 1);
                        cell.Subscribe(row);
                        row.AddCell(cell);
                    }
                }

                rows.Add(row);
                r++;
            }

            return rows;
        }

        public List<Column> CreateColumns(List<Row> rows)
        {
            int c;
            List<Column> columns = new List<Column>();

            foreach (Row row in rows)
            {
                c = 0;

                if (row.Id == 1)
                {
                    c = 1;

                    foreach (Cell cell in row)
                        columns.Add(new Column(c++));
                    c = 0;
                }

                foreach (Cell cell in row)
                {
                    cell.Subscribe(columns[c]);
                    columns[c++].AddCell(cell);
                }
            }

            return columns;
        }

        public List<Block> CreateBlocks(List<Row> rows)
        {
            List<Block> blocks = new List<Block>();

            for (int i = 0; i < rows.Count; i++)
                blocks.Add(new Block(i + 1));

            foreach (Row row in rows)
            {
                foreach(Cell cell in row)
                {
                    cell.Subscribe(blocks[cell.B - 1]);
                    blocks[cell.B - 1].AddCell(cell);
                }
            }

            return blocks;
        }
    }
}
