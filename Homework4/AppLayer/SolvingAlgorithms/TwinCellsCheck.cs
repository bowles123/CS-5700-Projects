using AppLayer.SudokuComponents;

namespace AppLayer.SolvingAlgorithms
{
    public class TwinCellsCheck : SolvingAlgorithm
    {
        public TwinCellsCheck() { actualType = "TWIN_CELLS_CHECK"; }

        public override bool CheckCell(Cell c)
        {
            if (c.Possibilities.Count == 2)
            {
                foreach(Cell cell in Puzzle.Rows[c.Y - 1])
                {
                    if (cell.X == c.X && cell.Y == c.Y) continue;

                    if (cell.Possibilities.Count == 2 && 
                        cell.Possibilities.Contains(c.Possibilities[0]) &&
                        cell.Possibilities.Contains(c.Possibilities[1]))
                    {
                        foreach (Cell _cell in Puzzle.Rows[c.Y - 1])
                        {
                            if (_cell.X != c.X && _cell.X != cell.X && _cell.Y != c.Y &&
                                _cell.Y != cell.Y && _cell.Value == '-')
                            {
                                _cell.RemovePossibility(c.Possibilities[0]);
                                _cell.RemovePossibility(c.Possibilities[1]);
                                return true;
                            }
                        }
                    }
                }

                foreach (Cell cell in Puzzle.Columns[c.X - 1])
                {
                    if (cell.X == c.X && cell.Y == c.Y) continue;

                    if (cell.Possibilities.Count == 2 &&
                        cell.Possibilities.Contains(c.Possibilities[0]) &&
                        cell.Possibilities.Contains(c.Possibilities[1]))
                    {
                        foreach (Cell _cell in Puzzle.Columns[c.X - 1])
                        {
                            if (_cell.X != c.X && _cell.X != cell.X && _cell.Y != c.Y &&
                                _cell.Y != cell.Y && _cell.Value == '-')
                            {
                                _cell.RemovePossibility(c.Possibilities[0]);
                                _cell.RemovePossibility(c.Possibilities[1]);
                                return true;
                            }
                        }
                    }
                }

                foreach (Cell cell in Puzzle.Blocks[c.B - 1])
                {
                    if (cell.X == c.X && cell.Y == c.Y) continue;

                    if (cell.Possibilities.Count == 2 &&
                        cell.Possibilities.Contains(c.Possibilities[0]) &&
                        cell.Possibilities.Contains(c.Possibilities[1]))
                    {
                        foreach (Cell _cell in Puzzle.Blocks[c.B - 1])
                        {
                            if (_cell.X != c.X && _cell.X != cell.X && _cell.Y != c.Y &&
                                _cell.Y != cell.Y && (_cell.Possibilities.Contains(c.Possibilities[0])
                                || _cell.Possibilities.Contains(c.Possibilities[1])))
                            {
                                _cell.RemovePossibility(c.Possibilities[0]);
                                _cell.RemovePossibility(c.Possibilities[1]);
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
