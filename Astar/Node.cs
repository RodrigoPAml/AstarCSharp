namespace Astar
{
    public class Node
    {
        public Point Position { get; } // Posição atual do nó
        public Node Parent { get; set; } // Nó anterior, usado para saber o caminho percorrido
        public double GCost { get; set; } // Custo do inicio até aqui
        public double HCost { get; } // Custo heuristico até o inicio (normalmente é a distance direta até esse ponto)
        public int NCurves { get; set; } // Número de curvas que esse caminho fez
        public double FCost => (GCost + HCost);

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
