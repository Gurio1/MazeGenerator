using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator
{
    public class MazeResolver
    {
        private readonly Maze _maze;
        private readonly Cell[] _cells;
        private readonly Direction[] _directions =
        {
            new Direction(1, 0), //Right
            new Direction(-1, 0), //Left
            new Direction(0, 1), // Up
            new Direction(0, -1) // Down
        };

        private const int WaveStartValue = 1;
        private readonly int[,] _wayProjection;

        private Point[] _resolvedMazeWay;

        public MazeResolver(Maze maze)
        {
            _maze = maze;
            _cells = maze.Cells.Cast<Cell>().ToArray();
            _wayProjection = new int [maze.Height, maze.Width];
        }

        public Point[] FindShortestWay()
        {
            var startCell = _cells.First(c => c.IsStart);

            var startCoordinate = startCell.GetCoordinate();

            _wayProjection[startCoordinate.Y, startCoordinate.X] = WaveStartValue;
            
            FindNeighbours(startCell,WaveStartValue + 1);
            
            return FillResolvedWay();
        }

        private Point[] FillResolvedWay()
        {
            var currentCell = _cells.First(c => c.IsEnd);
            
            var currentCellCoordinate = currentCell.GetCoordinate();

            var waveMaxValue = _wayProjection[currentCellCoordinate.Y, currentCellCoordinate.X];

            _resolvedMazeWay = new Point [waveMaxValue];
            _resolvedMazeWay[waveMaxValue - 1] = currentCellCoordinate;

            while (waveMaxValue > WaveStartValue)
            {
                waveMaxValue--;
                foreach (var direction in _directions)
                {
                    if (!TryGetCell(currentCell.GetCoordinate(), direction, out Cell cell)) continue;
                    
                    if (TryAddToResolvedWay(cell, waveMaxValue))
                    {
                        currentCell = cell;
                    }
                }
            }

            return _resolvedMazeWay;
        }

        private bool TryAddToResolvedWay(Cell cell,int waveLenght)
        {
            var cellCoordinate = cell.GetCoordinate();

            if (_wayProjection[cellCoordinate.Y, cellCoordinate.X] != waveLenght) return false;
            
            _resolvedMazeWay[waveLenght - 1] = cellCoordinate;
            
            return true;

        }
        
        /*private void FindNeighbours(Cell startCell,int waveVal)
        {
            Queue<(Cell cell, int waveValue)> queue = new Queue<(Cell cell, int waveValue)>();
            queue.Enqueue((startCell, waveVal));

            while (queue.Count > 0)
            {
                (Cell cell, int waveValue) = queue.Dequeue();

                foreach (var direction in _directions)
                {
                    if (!TryGetCell(cell.GetCoordinate(), direction, out Cell neighbor)) continue;

                    var neighborCoordinate = neighbor.GetCoordinate();

                    if (_wayProjection[neighborCoordinate.Y, neighborCoordinate.X] != 0) continue;

                    _wayProjection[neighborCoordinate.Y, neighborCoordinate.X] = waveValue;

                    if (neighbor.IsEnd)
                    {
                        return;
                    }

                    queue.Enqueue((neighbor, waveValue + 1));
                }
            }
        }*/

        private void FindNeighbours(Cell cell,int waveValue)
        {
            foreach (var direction in _directions)
            {
                if (!TryGetCell(cell.GetCoordinate(), direction, out Cell neighbor)) continue;
                
                var neighborCoordinate = neighbor.GetCoordinate();

                if (_wayProjection[neighborCoordinate.Y, neighborCoordinate.X] != 0) continue;
                
                _wayProjection[neighborCoordinate.Y, neighborCoordinate.X] = waveValue;

                if (neighbor.IsEnd)
                {
                    break;
                }
                
                FindNeighbours(neighbor,waveValue + 1);
            }
        }

        private bool TryGetCell(Point startCell, Direction direction,out Cell cell)
        {
            if (startCell.Y + direction.Y >= _maze.Height || startCell.X + direction.X >= _maze.Width ||
                startCell.X + direction.X < 0 ||
                startCell.Y + direction.Y < 0)
            {
                cell = null;
                return false;
            }
            
            switch (direction.Y)
            {
                case -1 when _maze.Cells[startCell.Y, startCell.X].BottomWall.IsBroken:
                    cell = _maze.Cells[startCell.Y + direction.Y, startCell.X + direction.X];
                    return true;
                case 1 when _maze.Cells[startCell.Y, startCell.X].TopWall.IsBroken:
                    cell = _maze.Cells[startCell.Y + direction.Y, startCell.X + direction.X];
                    return true;
                default:
                {
                    switch (direction.X)
                    {
                        case 1 when _maze.Cells[startCell.Y, startCell.X].RightWall.IsBroken:
                            cell = _maze.Cells[startCell.Y + direction.Y, startCell.X + direction.X];
                            return true;
                        case -1 when _maze.Cells[startCell.Y, startCell.X].LeftWall.IsBroken:
                            cell = _maze.Cells[startCell.Y + direction.Y, startCell.X + direction.X];
                            return true;
                    }

                    break;
                }
            }
            cell = null;
            return false;
        }
    }
}