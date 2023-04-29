using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class MazeControl : UserControl
    {
        private readonly Maze _maze;
        private readonly Bitmap _bitmap;
        private readonly int _cellSize;
        private readonly Form _mazePictureForm = new Form();
        private readonly Form _resolvedMazePictureForm = new Form();

        public MazeControl(Maze maze,int cellSize)
        {
            InitializeComponent();

            _cellSize =cellSize;
            _maze = maze;
            _bitmap = new Bitmap(_maze.Width * _cellSize + 1, _maze.Height * _cellSize + 1);
            Disposed += OnDispose;
        }

        public void DrawMaze()
        {
            if (_mazePictureForm.BackgroundImage != null)
            {
                _mazePictureForm.Close();
            }
            using (var graphics = Graphics.FromImage(_bitmap))
            {
                graphics.Clear(Color.White);

                for (int col = _maze.Height - 1; col >= 0; col--)
                {
                    for (int row = 0; row < _maze.Width; row++)
                    {
                        var cell = _maze.Cells[col, row];
                        var x = row * _cellSize;
                        var y = (_maze.Height - 1 - col) * _cellSize; // invert y-coordinate

                        if (!cell.TopWall.IsBroken)
                        {
                            graphics.DrawLine(Pens.Black, x, y, x + _cellSize, y);
                        }

                        if (!cell.LeftWall.IsBroken)
                        {
                            graphics.DrawLine(Pens.Black, x, y, x, y + _cellSize);
                        }

                        if (!cell.BottomWall.IsBroken)
                        {
                            graphics.DrawLine(Pens.Black, x, y + _cellSize, x + _cellSize, y + _cellSize);
                        }

                        if (!cell.RightWall.IsBroken)
                        {
                            graphics.DrawLine(Pens.Black, x + _cellSize, y, x + _cellSize, y + _cellSize);
                        }
                    }
                }

                _mazePictureForm.ClientSize = new Size(_maze.Width * _cellSize + 24, _maze.Height * _cellSize + 24);
                _mazePictureForm.BackgroundImage = _bitmap;
                _mazePictureForm.BackgroundImageLayout = ImageLayout.Center;
            }

            _mazePictureForm.StartPosition = FormStartPosition.Manual;
            _mazePictureForm.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - _mazePictureForm.Width, 0);
            _mazePictureForm.Show();
        }
        
        public void ShowResolvedWay(Point[] redBackgroundPoints)
        {
            if (_resolvedMazePictureForm.BackgroundImage != null)
            {
                _resolvedMazePictureForm.Close();
            }
            using (var graphics = Graphics.FromImage(_bitmap))
            {
                Pen pen = new Pen(Color.Lime, (float)_cellSize / 3); // create a pen with lime color and thickness of 1/3 of cell size
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (int i = 0; i < redBackgroundPoints.Length - 1; i++)
                {
                    var point1 = redBackgroundPoints[i];
                    var point2 = redBackgroundPoints[i + 1];
                    var x1 = point1.X  * _cellSize + _cellSize / 2;
                    var y1 = (_maze.Height - 1 - point1.Y) * _cellSize + _cellSize / 2; // invert y-coordinate
                    var x2 = point2.X * _cellSize + _cellSize / 2;
                    var y2 = (_maze.Height - 1 - point2.Y) * _cellSize + _cellSize / 2; // invert y-coordinate
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
            
            _resolvedMazePictureForm.ClientSize = new Size(_maze.Width * _cellSize + 24, _maze.Height * _cellSize + 24);
            _resolvedMazePictureForm.BackgroundImage = _bitmap;
            _resolvedMazePictureForm.BackgroundImageLayout = ImageLayout.Center;

            _resolvedMazePictureForm.Show();
        }
        private void OnDispose(object sender, EventArgs e)
        {
            _mazePictureForm.Close();
            _resolvedMazePictureForm.Close();
        }
    }
}