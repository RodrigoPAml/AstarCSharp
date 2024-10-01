namespace Astar
{
    /// <summary>
    /// Implementa busca de caminho A*
    /// </summary>
    public class Pathfinder
    {
        public List<IObstacle> Obstacles { get; set; }

        public Point Limits { get; set; }

        public bool AllowDiagonalSearch { get; set; } = false;

        public double CurvesWeight { get; set; } = 0.0;

        public DistanceTypeEnum DistanceType { get; set; } = DistanceTypeEnum.Manhattan;

        public bool HaveCurvePenalty => CurvesWeight > 0;

        private DateTime timer = DateTime.MinValue;

        public Pathfinder(List<IObstacle> obstacles, Point limits)
        {
            Obstacles = obstacles;
            Limits = limits;
        }

        public PathfindingResult? FindPath(Point initial, Point final)
        {
            timer = DateTime.UtcNow;

            // Lista a serem visitados
            var openList = new List<Node>();

            // Lista dos já visitados
            var closedList = new HashSet<Point>();

            // Adiciona nó inicial
            openList.Add(new Node(initial, null, 0, GetDistance(initial, final), 0));

            while (openList.Count > 0)
            {
                var currentNode = openList
                    .OrderBy(node => node.FCost)
                    .ThenBy(node => node.HCost)
                    .First();

                // Aqui é quando chegou na posição final, retorna resultado com lista de pontos
                if (currentNode.Position.X == final.X && currentNode.Position.Y == final.Y)
                    return ReconstructPath(currentNode, openList, closedList);

                openList.Remove(currentNode);
                closedList.Add(currentNode.Position);

                // Verificar os vizinhos
                foreach (var neighbor in GetNeighbors(currentNode.Position))
                {
                    if (closedList.Any(p => neighbor.X == p.X && neighbor.Y == p.Y) || Obstacles.Any(o => o.Intersects(neighbor)))
                        continue;

                    // Verifica se há mudança de direção (ou seja curva)
                    bool changed = ChangedDirection(currentNode, neighbor);

                    // Cálculo de custos do inicio ate aqui, que pode ou não levar curvas em conta
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

        private PathfindingResult ReconstructPath(Node currentNode, List<Node> openList, HashSet<Point> closeList)
        {
            var path = new List<Point>();
            var ncurves = currentNode?.NCurves ?? 0;

            while (currentNode != null)
            {
                path.Add(currentNode.Position);
                currentNode = currentNode.Parent;
            }

            path.Reverse();

            return new PathfindingResult()
            {
                ClosedNodes = closeList.ToList(),
                OpenedNodes = openList.Select(x => x.Position).ToList(),
                Path = path,
                TimeElapsed = (DateTime.UtcNow - timer).TotalMilliseconds,
                Curves = ncurves,
            };
        }
    }
}
