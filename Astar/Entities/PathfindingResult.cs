namespace Astar.Entities
{
    /// <summary>
    /// The result of the path finding algorithm
    /// </summary>
    public class PathfindingResult
    {
        /// <summary>
        /// The path from the initial to final node
        /// </summary>
        public List<Point> Path { get; set; } = new List<Point>();

        /// <summary>
        /// Visited nodes
        /// </summary>
        public List<Point> ClosedNodes { get; set; } = new List<Point>();

        /// <summary>
        /// Nodes to visit
        /// </summary>
        public List<Point> OpenedNodes { get; set; } = new List<Point>();

        /// <summary>
        /// Execution time
        /// </summary>
        public double TimeElapsed { get; set; } = 0;

        /// <summary>
        /// The number of curves of the best path founded
        /// </summary>
        public int Curves { get; set; } = 0;
    }
}
