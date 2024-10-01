namespace AstarGUI
{
    /// <summary>
    /// The GridDrawer class is responsible for rendering a 2D grid where each cell can be filled with a specific color.
    /// The grid can be resized and individual cell colors can be updated dynamically. It is used in graphical
    /// applications to visualize a grid, such as when displaying the A* algorithm in action.
    /// </summary>
    public class GridDrawer
    {
        /// <summary>
        /// Gets the size (in pixels) of each cell in the grid. The cell size is calculated based on the dimensions
        /// of the grid and the overall width and height of the drawing area.
        /// </summary>
        public int CellSize { get; private set; }

        /// <summary>
        /// Gets or sets the number of rows in the grid.
        /// </summary>
        public int Rows { get; private set; } = 1;

        /// <summary>
        /// Gets or sets the number of columns in the grid.
        /// </summary>
        public int Cols { get; private set; } = 1;

        /// <summary>
        /// Gets or sets the width of the drawing area in pixels.
        /// </summary>
        public int Width { get; set; } = 1;

        /// <summary>
        /// Gets or sets the height of the drawing area in pixels.
        /// </summary>
        public int Height { get; set; } = 1;

        /// <summary>
        /// Stores the color values for each cell in the grid, represented as a 2D list of Color objects.
        /// </summary>
        public List<List<Color>> Grid { get; private set; }

        /// <summary>
        /// Initializes a new instance of the GridDrawer class with the specified number of rows, columns, width, and height.
        /// </summary>
        /// <param name="rows">The number of rows in the grid.</param>
        /// <param name="cols">The number of columns in the grid.</param>
        /// <param name="width">The width of the drawing area in pixels.</param>
        /// <param name="height">The height of the drawing area in pixels.</param>
        public GridDrawer(int rows, int cols, int width, int height)
        {
            Rows = rows;
            Cols = cols;
            Width = width;
            Height = height;

            Init();
        }

        /// <summary>
        /// Initializes the grid and calculates the cell size based on the grid dimensions and overall drawing area size.
        /// </summary>
        private void Init()
        {
            CellSize = Math.Min(Width / Cols, Height / Rows);
            Clear();
        }

        /// <summary>
        /// Clears the grid by resetting all cells to the default color (White).
        /// </summary>
        public void Clear()
        {
            Grid = new List<List<Color>>();

            for (int i = 0; i < Rows; i++)
            {
                List<Color> row = new List<Color>();

                for (int j = 0; j < Cols; j++)
                    row.Add(Color.White);  // Initialize all cells with white color

                Grid.Add(row);
            }
        }

        /// <summary>
        /// Updates the grid size by setting a new number of rows and columns, and re-initializing the grid.
        /// </summary>
        /// <param name="rows">The new number of rows.</param>
        /// <param name="cols">The new number of columns.</param>
        public void SetGridSize(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            Init();
        }

        /// <summary>
        /// Sets the color of a specific cell in the grid.
        /// </summary>
        /// <param name="row">The row index of the cell.</param>
        /// <param name="col">The column index of the cell.</param>
        /// <param name="color">The color to set for the specified cell.</param>
        public void SetColor(int row, int col, Color color)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Cols)
                Grid[row][col] = color;
        }

        /// <summary>
        /// Converts the pixel coordinates (x, y) to the corresponding grid coordinates (row, col).
        /// </summary>
        /// <param name="x">The x-coordinate in pixels.</param>
        /// <param name="y">The y-coordinate in pixels.</param>
        /// <returns>A Point representing the grid coordinates.</returns>
        public Astar.Entities.Point GetCoordinate(int x, int y)
        {
            int col = x / CellSize;
            int row = y / CellSize;

            return new Astar.Entities.Point(row, col);
        }

        /// <summary>
        /// Draws the grid with filled cells, using the stored color values for each cell. It also draws the grid lines.
        /// </summary>
        /// <param name="g">The Graphics object used to draw the grid.</param>
        public void Draw(Graphics g)
        {
            // Calculate cell size based on current grid dimensions and drawing area
            CellSize = Math.Min(Width / Cols, Height / Rows);

            // Fill each cell with its corresponding color
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

            // Draw grid lines
            using (Pen pen = new Pen(Color.Black))
            {
                for (int i = 0; i <= Rows; i++)
                {
                    g.DrawLine(pen, 0, i * CellSize, Cols * CellSize, i * CellSize);  // Horizontal lines
                }

                for (int j = 0; j <= Cols; j++)
                {
                    g.DrawLine(pen, j * CellSize, 0, j * CellSize, Rows * CellSize);  // Vertical lines
                }
            }
        }
    }
}
