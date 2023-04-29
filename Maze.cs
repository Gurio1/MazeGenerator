using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator
{
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }
        
        private readonly Random _rnd = new Random();
        public Cell[,] Cells { get; }
        
        private readonly Stack<Cell> _cellsHistory = new Stack<Cell>();

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;

            Cells = new Cell[height, width];

            GenerateMaze();
        }

        public void GenerateMaze()
        {
            FillCells();

            var currentCell = Cells[_rnd.Next(0, Height), _rnd.Next(Width/4, Width)];
            currentCell.VisitCell();

            var enumerableCells = Cells.Cast<Cell>().ToArray();

            while (enumerableCells.Any(x => !x.IsVisited))
            {
                var coordinate = currentCell.GetCoordinate();

                currentCell = FindNonVisitedNeighbor(coordinate);

                currentCell.VisitCell();
            }

            currentCell = Cells[_rnd.Next(0, Height), 0];
            currentCell.LeftWall.Destroy();
            currentCell.SetStart();

            currentCell = Cells[_rnd.Next(0, Height), Width - 1];
            currentCell.RightWall.Destroy();
            currentCell.SetEnd();
        }
        
        private int GetRandomDirection(int range)
        {
            return _rnd.Next(0, range);
        }
        
        private Cell FindNonVisitedNeighbor(Point cellCoordinate)
        {
            var directions = new List<Direction>()
            {
                new Direction(1,0), //Right
                new Direction(-1,0),//Left
                new Direction(0,1), // Up
                new Direction(0,-1) // Down
            };

            while (directions.Count() != 0)
            {
                var directionPlace = GetRandomDirection(directions.Count);
                var direction = directions[directionPlace];

                if (cellCoordinate.Y + direction.Y >= Height || cellCoordinate.X + direction.X >= Width ||
                    cellCoordinate.X + direction.X < 0 ||
                    cellCoordinate.Y + direction.Y < 0)
                {
                    directions.RemoveAt(directionPlace);
                    continue;
                }

                var nextCell = Cells[cellCoordinate.Y + direction.Y, cellCoordinate.X + direction.X];

                if (!nextCell.IsVisited)
                {
                    _cellsHistory.Push(nextCell);
                    DestroyWall(direction, nextCell);
                    return nextCell;
                }

                directions.RemoveAt(directionPlace);
            }

            return FindFromPreviousCell();
        }
        
        private Cell FindFromPreviousCell()
        {
            var previousCell = _cellsHistory.Pop();

            return FindNonVisitedNeighbor(previousCell.GetCoordinate());
        }

        private void DestroyWall(Direction direction, Cell nextCell)
        {
            switch (direction.Y)
            {
                case -1:
                    nextCell.TopWall.Destroy();
                    break;
                case 1:
                    nextCell.BottomWall.Destroy();
                    break;
                default:
                {
                    if (direction.X == 1)
                    {
                        nextCell.LeftWall.Destroy();
                    }
                    else
                    {
                        nextCell.RightWall.Destroy();
                    }

                    break;
                }
            }
        }

        private void FillCells()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (i == 0 & j == 0)
                    {
                        var bottomRightCell = new Cell(j, i)
                        {
                            RightWall = new Wall(), BottomWall = new Wall(), LeftWall = new Wall(), TopWall = new Wall()
                        };
                        Cells[i, j] = bottomRightCell;
                    }
                    else if (i == 0 & j > 0)
                    {
                        var bottomSideCell = new Cell(j, i)
                        {
                            LeftWall = Cells[i, j - 1].RightWall, BottomWall = new Wall(), RightWall = new Wall(),
                            TopWall = new Wall()
                        };
                        Cells[i, j] = bottomSideCell;
                    }
                    else if (i > 0 & j == 0)
                    {
                        var rightSideCell = new Cell(j, i)
                        {
                            RightWall = new Wall(), BottomWall = Cells[i - 1, j].TopWall, LeftWall = new Wall(),
                            TopWall = new Wall()
                        };
                        Cells[i, j] = rightSideCell;
                    }
                    else
                    {
                        var defaultCell = new Cell(j, i)
                        {
                            TopWall = new Wall(), RightWall = new Wall(), LeftWall = Cells[i, j - 1].RightWall,
                            BottomWall = Cells[i - 1, j].TopWall
                        };
                        Cells[i, j] = defaultCell;
                    }
                }
            }
        }
    }
}