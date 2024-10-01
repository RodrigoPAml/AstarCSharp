namespace Astar
{
    public class PathfindingResult
    {
        /// <summary>
        /// Caminho
        /// </summary>
        public List<Point> Path { get; set; } = new List<Point>();

        /// <summary>
        /// Lista de nós visitados
        /// </summary>
        public List<Point> ClosedNodes { get; set; } = new List<Point>();

        /// <summary>
        /// Lista de nós a visitar
        /// </summary>
        public List<Point> OpenedNodes { get; set; } = new List<Point>();

        /// <summary>
        /// Tempo de execução
        /// </summary>
        public double TimeElapsed { get; set; } = 0;

        /// <summary>
        /// Número de curvas
        /// </summary>
        public int Curves { get; set; } = 0;
    }
}
