namespace MazeGenerator
{
    public struct Direction
    {
        public int X { get; }

        public int Y { get; }

        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}