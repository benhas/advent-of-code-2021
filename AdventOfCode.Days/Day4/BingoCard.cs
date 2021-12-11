using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode.Days.Day4
{
    public class BingoCard
    {
        public BingoCard(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            BingoCells = new List<BingoCell>();
        }
        
        private int Rows { get; }
        private int Cols { get; }
        public List<BingoCell> BingoCells { get; }
        public bool IsBingo { get; }

        public void ProcessBingoCardValue(int value)
        {
            var foundBingoCell = SeekBingoCell(value);
            if (foundBingoCell.Any())
            {
                foundBingoCell.First().Selected = true;
                
            }
        }
        internal IEnumerable<BingoCell> SeekBingoCell(int pickedValue)
        {
            return this.BingoCells.Where(x => x.Value == pickedValue);
        }
        
        internal bool CheckForBingo()
        {
            return CheckRows() && CheckColumns() && CheckDiagonals();
        }

        internal bool CheckRows()
        {
            var fullRow = false;
            for (var i = 0; i < Rows; i++)
            {
                if (CheckRow(i)) break;
            }
            return fullRow;
        }

        internal bool CheckRow(int rowNo)
        {
            return BingoCells.All(bc => bc.X == rowNo && bc.Selected);
        }

        internal bool CheckColumns()
        {
            var fullCol = false;
            for (var i = 0; i < Cols; i++)
            {
                if (BingoCells.All(bc => bc.Y == i && bc.Selected))
                {
                    fullCol = true;
                    break;
                }
            }
            return fullCol;
        }

        internal bool CheckDiagonals()
        {
            return CheckDownwardsDiagonal() && CheckUpwardsDiagonal();
        }

        internal bool CheckDownwardsDiagonal()
        {
            return false;
        }

        internal bool CheckUpwardsDiagonal()
        {
            return false;
        }
    }
}