namespace LifeGame
{
    class Cell
    {
        public int X { get; }
        public int Y { get; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => obj is Cell && ((Cell) obj).X == X && ((Cell) obj).Y == Y;

        public override int GetHashCode() => $"{X}{Y}".GetHashCode();
    }
}
