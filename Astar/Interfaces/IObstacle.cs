using Astar.Entities;

namespace Astar.Interfaces
{
    /// <summary>
    /// Interface for generic obstacle verification
    /// </summary>
    public interface IObstacle
    {
        /// <summary>
        /// If a point intersects with this obstacle
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        bool Intersects(Point point);

        /// <summary>
        /// Points that compose this obstacle
        /// </summary>
        /// <returns></returns>
        List<Point> GetPoints();
    }
}
