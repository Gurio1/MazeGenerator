using System;

namespace MazeGenerator
{
    public class Cell
    {
        private readonly Point _coordinate;
        public Wall TopWall { get; set; }
        public Wall LeftWall { get; set; }
        public Wall BottomWall { get; set; }
        public Wall RightWall { get; set; }
        public bool IsVisited { get; private set; }
        
        public bool IsStart { get; private set; }
        
        public bool IsEnd { get; private set; }

        public Cell(int x,int y)
        {
            _coordinate = new Point(x, y);
        }

        public Point GetCoordinate()
        {
            return _coordinate;
        }

        public void SetStart()
        {
            IsStart = true;
        }

        public void SetEnd()
        {
            IsEnd = true;
        }

        public void VisitCell()
        {
            if (IsVisited)
            {
                throw new Exception("Cell have been visited");
            }
            IsVisited = true;
        }
    }
}