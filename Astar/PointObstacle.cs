namespace Astar
{
    /// <summary>
    /// Obstaculo do tipo ponto
    /// </summary>
    public class PointObstacle : IObstacle
    {
        public Point Position { get; private set; }

        public PointObstacle(Point position)
        {
            Position = position;
        }

        public bool Intersects(Point point)
        {
            return Position.X == point.X && Position.Y == point.Y;
        }

        public List<Point> GetPoints()
        {
            return new List<Point>() { Position };
        }
    }
}

