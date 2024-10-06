 using Astar.Entities;
using Astar.Enums;
using Astar.Interfaces;

namespace Astar
{
    /// <summary>
    /// A* path finding implementation
    /// </summary>
    public class Pathfinder
    {
        /// <summary>
        /// List of obstacles
        /// </summary>
        public List<IObstacle> Obstacles { get; set; }

        /// <summary>
        /// The limits of search for the grid (max x, max y)
        /// </summary>
        public Point Limits { get; set; }

        /// <summary>
        /// If the algorithm can use diagonal directions to search
        /// </summary>
        public bool AllowDiagonalSearch { get; set; } = false;

        /// <summary>
        /// The penalty for turn/curve in paths
        /// </summary>
        public double CurvesWeight { get; set; } = 0.0;
        public bool HaveCurvePenalty => CurvesWeight > 0;

        /// <summary>
        /// The distance algorithm used for the heuristic
        /// </summary>
        public DistanceTypeEnum DistanceType { get; set; } = DistanceTypeEnum.Manhattan;

        /// <summary>
        /// Timer for execution time
        /// </summary>
        private DateTime timer = DateTime.MinValue;

        public Pathfinder(List<IObstacle> obstacles, Point limits)
        {
            Obstacles = obstacles;
            Limits = limits;
        }

        /// <summary>
        /// Finds the path between initial and final points or return null if not finded
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public PathfindingResult FindPath(Point initial, Point final)
        {
            timer = DateTime.UtcNow;

            // Nodes to be visited
            var openList = new List<Node>();

            // Visited nodes
            var closedList = new HashSet<Node>();

            // Initial node
            openList.Add(new Node(initial, null, 0, GetDistance(initial, final), 0));

            while (openList.Count > 0)
            {
                var currentNode = openList
                    .OrderBy(node => node.FCost)
                    .ThenBy(node => node.HCost)
                    .First();

                // Reach final position, return the path
                if (currentNode.Position.X == final.X && currentNode.Position.Y == final.Y)
                     return ReconstructPath(currentNode, openList, closedList);

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                // Verify neighbors
                foreach (var neighbor in GetNeighbors(currentNode.Position))
                {
                    if (closedList.Any(p => neighbor.X == p.Position.X && neighbor.Y == p.Position.Y) || Obstacles.Any(o => o.Intersects(neighbor)))
                        continue;

                    // Verify if turned or have a curve in the path
                    bool changed = ChangedDirection(currentNode, neighbor);

                    // GCost calculation
                    var gCost = currentNode.GCost + GetDistance(currentNode.Position, neighbor);
                    int nCurves = currentNode.NCurves + (changed ? 1 : 0);
                    var cCost = (changed ? CurvesWeight : 0); // Adiciona 1 nova curva ao peso
                    var totalGCost = gCost + (HaveCurvePenalty ? cCost : 0);

                    var existingNode = openList.FirstOrDefault(n =>
                        n.Position.X == neighbor.X &&
                        n.Position.Y == neighbor.Y
                    );

                    if (existingNode == null)
                    {
                        openList.Add(new Node(neighbor, currentNode, totalGCost, GetDistance(neighbor, final), nCurves));
                    }
                    else if (totalGCost < existingNode.GCost)
                    {
                        existingNode.Parent = currentNode;
                        existingNode.GCost = totalGCost;
                        existingNode.NCurves = nCurves;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Verify if its a curve/turn
        /// </summary>
        /// <param name="current"></param>
        /// <param name="newPoint"></param>
        /// <returns></returns>
        public bool ChangedDirection(Node current, Point newPoint)
        {
            if (current.Parent == null)
                return false;

            int parentToCurrentX = current.Position.X - current.Parent.Position.X;
            int parentToCurrentY = current.Position.Y - current.Parent.Position.Y;

            int currentToNewX = newPoint.X - current.Position.X;
            int currentToNewY = newPoint.Y - current.Position.Y;

            parentToCurrentX = NormalizeDirection(parentToCurrentX);
            parentToCurrentY = NormalizeDirection(parentToCurrentY);
            currentToNewX = NormalizeDirection(currentToNewX);
            currentToNewY = NormalizeDirection(currentToNewY);

            bool directionChangedX = parentToCurrentX != currentToNewX;
            bool directionChangedY = parentToCurrentY != currentToNewY;

            return directionChangedX || directionChangedY;
        }

        private int NormalizeDirection(int value)
        {
            if (value > 0) return 1;
            if (value < 0) return -1;
            return 0;
        }

        /// <summary>
        /// Return the neighbors
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private List<Point> GetNeighbors(Point point)
        {
            var neighbors = new List<Point>
            {
                new Point(point.X + 1, point.Y),
                new Point(point.X - 1, point.Y),
                new Point(point.X, point.Y + 1),
                new Point(point.X, point.Y - 1),
            };

            if (AllowDiagonalSearch)
            {
                neighbors.AddRange(new List<Point>
                {
                    new Point(point.X + 1, point.Y + 1),
                    new Point(point.X + 1, point.Y - 1),
                    new Point(point.X - 1, point.Y + 1),
                    new Point(point.X - 1, point.Y - 1),
                });
            }

            neighbors = neighbors.Where(p =>
                (p.X >= 0 && p.Y >= 0) &&
                (p.X < Limits.X && p.Y < Limits.Y))
             .ToList();

            return neighbors;
        }

        /// <summary>
        /// Return the distance between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private double GetDistance(Point a, Point b)
        {
            switch (DistanceType)
            {
                default:
                case DistanceTypeEnum.Chebyshev:
                    int dx = Math.Abs(a.X - b.X);
                    int dy = Math.Abs(a.Y - b.Y);
                    return Math.Max(dx, dy);
                case DistanceTypeEnum.Manhattan:
                    return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
                case DistanceTypeEnum.Euclidean:
                    return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            }
        }

        /// <summary>
        /// Prepare the result
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="openList"></param>
        /// <param name="closeList"></param>
        /// <returns></returns>
        private PathfindingResult ReconstructPath(Node currentNode, List<Node> openList, HashSet<Node> closeList)
        {
            var path = new List<Node>();
            var ncurves = currentNode?.NCurves ?? 0;

            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return new PathfindingResult()
            {
                ClosedNodes = closeList.ToList(),
                OpenedNodes = openList,
                Path = path,
                TimeElapsed = (DateTime.UtcNow - timer).TotalMilliseconds,
                Curves = ncurves,
            };
        }
    }
}
