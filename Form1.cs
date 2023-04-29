using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        private Maze _maze;
        private MazeControl _mazeControl;
        private int _cellSize;

        public Form1()
        {
            InitializeComponent();
            WidthValue.Value = 50;
            HeightValue.Value = 30;
            CellSizeValue.Value = 20;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Controls.Add(_mazeControl);
        }

        private void ResolveButton_Click(object sender, EventArgs e)
        {
            var mazeResolver = new MazeResolver(_maze);
            var way =mazeResolver.FindShortestWay();
            
            _mazeControl.ShowResolvedWay(way);

            WindowState = FormWindowState.Minimized;
            ResolveButton.Enabled = false;
        }

        private void GenerateMazeClick(object sender, EventArgs e)
        {
            _maze = new Maze((int)WidthValue.Value, (int)HeightValue.Value);

            _maze.GenerateMaze();
            
            _cellSize = (int)CellSizeValue.Value;

            _mazeControl?.Dispose();

            _mazeControl = new MazeControl(_maze,_cellSize);
            _mazeControl.Dock = DockStyle.Fill;
            
            _mazeControl.DrawMaze();
            ResolveButton.Enabled = true;
        }
    }
}