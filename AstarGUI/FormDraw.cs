using Astar;
using Microsoft.VisualBasic.Devices;
using Point = Astar.Point;

namespace AstarGUI
{
    public partial class FormDraw : Form
    {
        private GridDrawer _drawer = null;

        private bool isMouseDown = false;

        private List<IObstacle> _obstacles = new List<IObstacle>();

        private Point initial = new Point(0, 0);

        private Point final = new Point(1, 1);

        private Point mousePos = new Point(0, 0);

        private DistanceTypeEnum distanceType = DistanceTypeEnum.Manhattan;

        public FormDraw()
        {
            InitializeComponent();

            numericColumns.Value = 20;
            numericRows.Value = 20;

            _drawer = new GridDrawer(
                (int)numericRows.Value,
                (int)numericColumns.Value,
                panel.ClientSize.Width,
                panel.ClientSize.Height
            );

            panel.Paint += onPaint;
            panel.MouseDown += panel_MouseDown;
            panel.MouseUp += panel_MouseUp;
            panel.MouseMove += panel_MouseMove;
            panel.SizeChanged += panel_SizeChanged;

            numericRows.ValueChanged += numericRows_ValueChanged;
            numericColumns.ValueChanged += numericColumns_ValueChanged;

            this.KeyDown += FormDraw_KeyDown;
            this.KeyPreview = true;

            comboBoxDistance.SelectedIndex = (int)distanceType;
        }

        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            _drawer.Width = panel.ClientSize.Width;
            _drawer.Height = panel.ClientSize.Height;

            _drawer.Draw(g);

            _drawer.SetColor(initial.X, initial.Y, Color.Green);
            _drawer.SetColor(final.X, final.Y, Color.Red);

            foreach (var obstacle in _obstacles)
            {
                foreach (var point in obstacle.GetPoints())
                {
                    _drawer.SetColor(point.X, point.Y, Color.Black);
                }
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            PaintCellIfMouseClicked(e.X, e.Y);
            RemoveInputsFocus();
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = new Point(e.X, e.Y);
            PaintCellIfMouseClicked(e.X, e.Y);
        }

        private void RemoveInputsFocus()
        {
            btnFind.Focus();
        }

        private void FormDraw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var coord = _drawer.GetCoordinate(mousePos.X, mousePos.Y);

                if (_obstacles.Any(x => x.Intersects(coord)))
                {
                    _obstacles = _obstacles.Where(x => !x.Intersects(coord)).ToList();
                    _drawer.Clear();
                    panel.Invalidate();
                }

                return;
            }

            if (numericColumns.Focused || numericRows.Focused || numericCurves.Focused)
                return;

            if (e.KeyCode == Keys.D1)
            {
                var coord = _drawer.GetCoordinate(mousePos.X, mousePos.Y);

                foreach (var obstacle in _obstacles)
                {
                    if (obstacle.Intersects(coord))
                    {
                        return;
                    }
                }

                initial = coord;
                _drawer.Clear();
                panel.Invalidate();
            }

            if (e.KeyCode == Keys.D2)
            {
                var coord = _drawer.GetCoordinate(mousePos.X, mousePos.Y);

                foreach (var obstacle in _obstacles)
                {
                    if (obstacle.Intersects(coord))
                    {
                        return;
                    }
                }

                final = coord;
                _drawer.Clear();
                panel.Invalidate();
            }
        }

        private void PaintCellIfMouseClicked(int mouseX, int mouseY)
        {
            if (isMouseDown)
            {
                var coord = _drawer.GetCoordinate(mouseX, mouseY);
                var obstacle = new PointObstacle(coord);

                if (obstacle.Intersects(initial) || obstacle.Intersects(final))
                    return;

                _obstacles.Add(obstacle);
                panel.Invalidate();
            }
        }

        private void panel_SizeChanged(object sender, EventArgs e)
        {
            _drawer.Width = panel.ClientSize.Width;
            _drawer.Height = panel.ClientSize.Height;
            panel.Invalidate();
        }

        private void numericRows_ValueChanged(object sender, EventArgs e)
        {
            _drawer?.SetGridSize((int)numericRows.Value, (int)numericColumns.Value);
            panel.Invalidate();
        }

        private void numericColumns_ValueChanged(object sender, EventArgs e)
        {
            _drawer?.SetGridSize((int)numericRows.Value, (int)numericColumns.Value);
            panel.Invalidate();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _drawer.Clear();
            Pathfinder pathfinder = new Pathfinder(_obstacles, new Point((int)numericRows.Value, (int)numericColumns.Value));
            pathfinder.AllowDiagonalSearch = checkDiagonal.Checked;
            pathfinder.CurvesWeight = (double)numericCurves.Value;
            pathfinder.DistanceType = (DistanceTypeEnum)comboBoxDistance.SelectedIndex;

            var path = pathfinder.FindPath(initial, final);

            if (path == null)
            {
                labelRes.Text = string.Empty;
                labelCurves.Text = "No path founded";
                labelClose.Text = string.Empty;
                labelOpen.Text = string.Empty;

                panel.Invalidate();
                return;
            }

            labelRes.Text = $"Path founded: in {path.TimeElapsed} ms";
            labelClose.Text = $"Closed nodes: {path.ClosedNodes.Count}";
            labelOpen.Text = $"Opened nodes: {path.OpenedNodes.Count}";
            labelCurves.Text = $"Curves: {path.Curves}";

            // Nos a visitar
            if(checkBoxOpen.Checked)
            {
                foreach (var point in path.OpenedNodes)
                {
                    _drawer.SetColor(point.X, point.Y, Color.LightGray);
                }
            }

            // Nos visitados
            if (checkBoxClosed.Checked)
            {
                foreach (var point in path.ClosedNodes)
                {
                    _drawer.SetColor(point.X, point.Y, Color.LightBlue);
                }
            }

            foreach (var point in path.Path)
            {
                _drawer.SetColor(point.X, point.Y, Color.Blue);
            }

            panel.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _obstacles = new List<IObstacle>();
            initial = new Point(0, 0);
            final = new Point(1, 1);
            _drawer.Clear();
            panel.Invalidate();
        }
    }
}
