using System.IO;
using System;
using System.Collections.Generic;

namespace AppLayer.SudokuComponents
{
    public class PuzzleFactory
    {
        public Puzzle Create(string file)
        {
            Puzzle puzzle = null;
            List<Row> rows;
            List<Column> columns;
            StreamReader reader = new StreamReader(file);
            List<char> possibleSymbols = new List<char>();
            int size = Convert.ToInt32(reader.ReadLine());
            string symbols = reader.ReadLine();

            foreach (char symbol in symbols)
                possibleSymbols.Add(symbol);

            rows = CreateRows(ref reader);
            columns = CreateColumns(rows);

            return new Puzzle(rows, columns, CreateBlocks(rows, columns), possibleSymbols);
        }

        public List<Row> CreateRows(ref StreamReader reader)
        {
            int c, r = 1;
            List<Row> rows = new List<Row>();

            while (!reader.EndOfStream)
            {
                Row row = new Row(r);
                Cell cell;
                string values = reader.ReadLine();
                c = 1;

                foreach (char symbol in values)
                {
                    cell = new Cell(symbol, r, c++);
                    row.AddCell(cell);
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
                c = 1;

                if (row.Id == 1)
                {
                    foreach (Cell cell in row.Cells)
                        columns.Add(new Column(c++));
                    continue;
                }

                foreach (Cell cell in row.Cells)
                    columns[c++].AddCell(cell);
            }

            return columns;
        }

        public List<Block> CreateBlocks(List<Row> rows, List<Column> columns)
        {
            List<Block> blocks = new List<Block>();
            int b = 1;

            foreach (Row row in rows)
            {
                Block block;

                if (row.Id <= Math.Sqrt(row.Cells.Count)) block = new Block(b++);

                for (int i = 0; i < Math.Sqrt(row.Cells.Count); i++)
                {

                }
            }

            return blocks;
        }
    }
}
