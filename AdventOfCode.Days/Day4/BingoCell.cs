namespace AdventOfCode.Days.Day4
{
    public class BingoCell
    {
        public BingoCell(int x, int y, int value, bool selected= false)
        {
            X = x;
            Y = y;
            Value = value;
            Selected = selected;
        }

        public int X { get; }

        public int Y { get; }
        
        public int Value { get; }
        
        public bool Selected { get; set; }
    }
}