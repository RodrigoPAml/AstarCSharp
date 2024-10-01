namespace Astar
{
    /// <summary>
    /// Interface para obstaculos no A*
    /// </summary>
    public interface IObstacle
    {
        bool Intersects(Point point);

        List<Point> GetPoints();
    }
}
