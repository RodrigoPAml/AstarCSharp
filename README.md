# A* Algorithm with Turn Penalty

This repository implements an A* (A-star) pathfinding algorithm with a customizable **turn or curve penalty**. 

The algorithm not only finds the shortest path but also allows for the possibility to penalize turns, enabling the discovery of paths that are not necessarily the shortest but have fewer turns.

This can be especially useful in scenarios where smoother or more direct paths are preferable over the strictly shortest route.

![image](https://github.com/user-attachments/assets/c0f0a43f-4e04-40a7-9882-e6f4e1875a4f)

## Features

- **Turn Penalty:** Adjust the penalty for turns to favor paths with fewer directional changes.
- **2D Visualization**: A Windows form application was build to show the algorithm running adn mess with parameters
- **Flexible Obstacles:** Add obstacles that the algorithm will navigate around.
- **Choose heuristic algorithm:** Choose the best fitting algorithm via windows form (Chebyshev, Euclidean, Manhattan).
- **Efficient Pathfinding:** Standard A* optimization to ensure fast pathfinding while considering penalties and enabling diagonal paths.
- **Customizable Grid:** Easily set up a grid with start and end points, insert obstacles and choose grid size.
- **Nodes visualization:** Possibility to see open and close lists, where obstacles are in black, green is the initial node, red is the destiny node, dark blue is the founded path, light gray is the open nodes and light blue is the closed nodes.

## How It Works

The algorithm works similarly to the traditional A* but includes an additional cost for every turn made along the path. This penalty can be configured, making the pathfinding process favor routes with fewer changes in direction even if they are slightly longer in distance.

In a traditional A* algorithm, pathfinding is based on two key costs:

1. G Cost: Represents the movement cost from the starting point to the current node.
2. H Cost: Represents the heuristic estimate from the current node to the goal.

**Turn Penalty in G Cost**

In this modified version of the A* algorithm, the G cost includes an additional factor: the turn penalty. If this feature is enabled, the G cost is not just the movement cost from the start node to the current node, but also accounts for the number of turns made along the path.

Here a example with no curve penalty

![image](https://github.com/user-attachments/assets/b1aee403-3756-4b5d-8259-9ed13d8a6f16)

And here is with curve penalty

![image](https://github.com/user-attachments/assets/f094a037-3085-4a9d-874e-1c231e8012e3)