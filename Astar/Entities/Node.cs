namespace Astar.Entities
{
    /// <summary>
    /// Defines a node in the astar algorithm
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Current position
        /// </summary>
        public Point Position { get; }

        /// <summary>
        /// Node parent, used to retrieve the previous path
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// The cost from the initial node to this 
        /// This cost may also include curve penalty
        /// </summary>
        public double GCost { get; set; }

        /// <summary>
        /// Heuristic cost, the direct distance between this node and the destiny node
        /// </summary>
        public double HCost { get; }

        /// <summary>
        /// The number of curves to reach this point
        /// </summary>
        public int NCurves { get; set; }

        /// <summary>
        /// The total cost of this node
        /// </summary>
        public double FCost => GCost + HCost;

        public Node(Point position, Node parent, double gCost, double hCost, int nCurves)
        {
            Position = position;
            Parent = parent;
            GCost = gCost;
            HCost = hCost;
            NCurves = nCurves;
        }
    }
}
