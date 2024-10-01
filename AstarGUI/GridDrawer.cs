namespace AstarGUI
{
    /// <summary>
    /// Class a grid with filled quads into it
    /// </summary>
    public class GridDrawer
    {
        public int CellSize { get; private set; }
        public int Rows { get; private set; } = 1;
        public int Cols { get; private set; } = 1;
        public int Width { get; set; } = 1;
        public int Height { get; set; } = 1;

        public List<List<Color>> Grid { get; private set; }

        public GridDrawer(int rows, int cols, int width, int height)
        {
            Rows = rows;
            Cols = cols;
            Width = width;
            Height = height;

            Init();
        }

        private void Init()
        {
            CellSize = Math.Min(Width / Cols, Height / Rows);
            Clear();
        }

        public void Clear()
        {
            Grid = new List<List<Color>>();

            for (int i = 0; i < Rows; i++)
            {
                List<Color> row = new List<Color>();

                for (int j = 0; j < Cols; j++)
                    row.Add(Color.White);

                Grid.Add(row);
            }
        }

        public void SetGridSize(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            Init();
        }

        public void SetColor(int row, int col, Color color)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Cols)
                Grid[row][col] = color;
        }

        public Astar.Point GetCoordinate(int x, int y)
        {
            int col = x / CellSize;
            int row = y / CellSize;

            return new Astar.Point(row, col);
        }

        public void Draw(Graphics g)
        {
            CellSize = Math.Min(Width / Cols, Height / Rows);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    using (Brush brush = new SolidBrush(Grid[i][j]))
                    {
                        g.FillRectangle(brush, j * CellSize, i * CellSize, CellSize, CellSize);
                    }
                }
            }

            using (Pen pen = new Pen(Color.Black))
            {
                for (int i = 0; i <= Rows; i++)
                {
                    g.DrawLine(pen, 0, i * CellSize, Cols * CellSize, i * CellSize);
                }

                for (int j = 0; j <= Cols; j++)
                {
                    g.DrawLine(pen, j * CellSize, 0, j * CellSize, Rows * CellSize);
                }
            }
        }
    }
}
