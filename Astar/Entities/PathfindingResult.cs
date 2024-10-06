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
        public List<Node> Path { get; set; } = new List<Node>();

        /// <summary>
        /// Visited nodes
        /// </summary>
        public List<Node> ClosedNodes { get; set; } = new List<Node>();

        /// <summary>
        /// Nodes to visit
        /// </summary>
        public List<Node> OpenedNodes { get; set; } = new List<Node>();

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
