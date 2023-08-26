using System.Collections;
using System.Collections.Generic;

using System;
using System.Linq;

public class FindPath
{
	public FindPath() { }
	//An array to store the shortest path
	public List<SuperNode> shortestPath = null;
	//A 2D array of test nodes that matches the maze map
	public List<List<SuperNode>> nodeMap_ar;
	//The path's start and end nodes
	public long startNode_ID = 0;
	public long destinationNode_ID = 0;
	//How much it will cost to move between nodes?
	private long _straightCost = 0;
	private long _diagonalCost = 0;

	public List<SuperNode> findShortestPath(
		 long startNode_ID,
		long destinationNode_ID,
		List<long[]> map_ar,
		long wallObstacle,
		string heuristic,
		long straightCost,
		long diagonalCost
	)
	{

		this.startNode_ID = startNode_ID;
		this.destinationNode_ID = destinationNode_ID;
		_straightCost = straightCost;
		_diagonalCost = diagonalCost;
		//Initialize the shortestPath array
		shortestPath = new List<SuperNode>();
		//Initialize the node map
		nodeMap_ar = initializeNodeMap(map_ar);
		//Initialize the closed and open list arrays
		List<SuperNode> closedList_ar = new List<SuperNode>();
		List<SuperNode> openList_ar = new List<SuperNode>();//Get the current center node. The first one will
															//be the startNode_ID, which is the player's start position.,

		//Object centerNode= nodeMap[uint(startNode_ID % 100)][uint(startNode_ID / 100)];

		// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
		SuperNode centerNode = nodeMap_ar[(int)(startNode_ID % 100)][(int)(startNode_ID / 100)];
		//Get a reference to the destinationNode. It will
		//match the destinationNode_ID

		// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
		SuperNode destinationNode = new SuperNode();
		if (nodeMap_ar.Count >= (int)(destinationNode_ID % 100))
		{
			destinationNode = nodeMap_ar[(int)(destinationNode_ID % 100)][(int)(destinationNode_ID / 100)];
		}
		//Loop until the destination node is found

		while (centerNode.id != destinationNode_ID)
		{

			//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ 8 пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ
			for (int column = -1; column < 2; column++)
			{
				for (int row = -1; row < 2; row++)
				{
					// Find the row and column to test
					int testRow = centerNode.row + row;
					int testColumn = centerNode.column + column;
					//Make sure that the row and column being tested are
					//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ


					if (testRow > -1 && testRow < nodeMap_ar.Count && testColumn > -1 && testColumn < nodeMap_ar[0].Count)
					{


						//If the test node isn't the centerNode
						//and the mazeMap doesn't contain a wall tile...
						if (nodeMap_ar[testRow][testColumn].id != centerNode.id &&
								map_ar[testRow][testColumn] != wallObstacle)
						{


							//Get a reference to the surrounding node

							SuperNode testNode = nodeMap_ar[testRow][testColumn];

							//Find out whether the node is on a straight axis or
							//a diagonal axis, and assign the appropriate cost
							//A. Declare the cost variable
							long costPath;
							//B. Do they occupy the same row or column?
							if (centerNode.row == testNode.row
							|| centerNode.column == testNode.column)
							{
								//... if they do, assign a cost of "10"
								costPath = straightCost;
							}
							else
							{
								//otherwise, assign a cost of "14"
								costPath = diagonalCost;
							}
							// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
							long kolGroundCost = map_ar[testRow][testColumn];
							//kolGroundCost =1;
							//costPath+=kolGroundCost;

							//C. Calculate the costs (g, h and f)
							//The node's current cost
							long groundCost = centerNode.groundCost + costPath;
							//The cost of travelling from this node to the
							//destination node (the heuristic)
							long hPathCost = 0;
							//int typeHeuristic=0;
							if (heuristic == "manhattan")
							{
								hPathCost = manhattan(testNode, destinationNode);
							}
							if (heuristic == "euclidean")
							{
								hPathCost = euclidean(testNode, destinationNode);
							}
							if (heuristic == "diagonal")
							{
								hPathCost = diagonal(testNode, destinationNode);
							}

							//hPathCost+=kolGroundCost;
							//manhattan
							long road = Math.Abs
							(testNode.row - destinationNode.row) * kolGroundCost
							+ Math.Abs
							(testNode.column - destinationNode.column) * kolGroundCost;
							hPathCost += road;
							/*
							if (kolGroundCost == 0)
							{
								hPathCost = 0;
								 groundCost -=1;
							}
							*/
							//hPathCost +=kolGroundCost;
							//groundCost -=kolGroundCost;

							//The final cost
							long finalCostSum = groundCost + hPathCost;


							//Find out if the testNode is in either
							//the openList or closedList array
							bool isOnOpenList = false;
							bool isOnClosedList = false;//Check the openList

							for (int i = 0; i < openList_ar.Count; i++)
							{
								if (testNode == openList_ar[i])
								{
									isOnOpenList = true;
								}
							}

							//Check the closedList
							for (int j = 0; j < closedList_ar.Count; j++)
							{
								if (testNode == closedList_ar[j])
								{
									isOnClosedList = true;
								}
							}

							//If it's on either of these lists, we can check
							//whether this route is a lower-cost alternative
							//to the previous cost calculation. The new G cost
							//will make the difference to the final F cost
							if (isOnOpenList || isOnClosedList)
							{
								if (testNode.finalCost > finalCostSum)
								{
									testNode.finalCost = finalCostSum;
									testNode.groundCost = groundCost;
									testNode.hCost = hPathCost;
									//Only change the parent if the new cost is lower
									testNode.parent = centerNode;
								}
							}
							else
							{
								testNode.finalCost = finalCostSum;
								testNode.groundCost = groundCost;
								testNode.hCost = hPathCost;
								testNode.parent = centerNode;
								openList_ar.Add(testNode);
							}
						}
					}
				}
			}
			//Push the current centerNode into the closed list

			closedList_ar.Add(centerNode);
			//Quit the loop if there's nothing on the open list.;
			//This means that there is no path to the destination or the
			//destination is invalid, like a wall tile
			if (openList_ar.Count == 0)
			{
				//trace("No path found");
				return shortestPath;
			}
			//Sort the open list according to final cost

			//Collections.sort(openList_ar, new CustomComparator());

			openList_ar = openList_ar.OrderBy(a => a.finalCost).ToList();

			//Set the node with the lowest final cost as the new;

			//centerNode = openList_ar.remove(0);
			var last = openList_ar[0];
openList_ar.RemoveAt(0);
			centerNode = last;
			//centerNode = openList_ar;
		}

		//Now that we have all the candidates, let's
		//find the shortest path!
		if (openList_ar.Count != 0)
		{
			//Start with the destination node
			SuperNode node = destinationNode;

			shortestPath.Add(node);
			//Work backwards through the node parents;
			//until the start node is found
			while (node.id != startNode_ID)
			{
				//Step through the parents of each node,
				//starting with the destination node
				//and ending with the start node
				node = node.parent;
				//Add the node to the beginning of the array
				//shortestPath.unshift(node);
				//shortestPath.Add(0, node);
				shortestPath.Insert(0, node);
				//...and then loop again to the next node's parent till you;
				//reach the end of the path
			}
		}
		return shortestPath;
	}
	public List<List<SuperNode>> initializeNodeMap(List<long[]> map)
	{
		//A blank array to store the nodes
		List<List<SuperNode>> nodeMap = new List<List<SuperNode>>();
		for (int row = 0; row < map.Count; row++)
		{

			nodeMap.Add(new List<SuperNode>());
			for (int column = 0; column < map[0].Length; column++)
			{
				//Create the node object and initialize the
				//values it will need to track
				SuperNode superNode = new SuperNode();
				superNode.finalCost = 0;
				superNode.groundCost = 0;
				superNode.hCost = 0;
				superNode.parent = null;
				//Assign the row and column
				superNode.row = row;
				superNode.column = column;
				//Assign the node's unique ID number
				superNode.id = (column * 100) + row;
				//Add the node object to this cell
				//nodeMap[row][column] = node;
				nodeMap[row].Add(superNode);
			}
		}
		//Return the nodeMap array

		return nodeMap;
	}
	//Heuristic methods
	//1. Manhattan
	private long manhattan(SuperNode testNode, SuperNode destinationNode)
	{
		long h
		= Math.Abs
		(testNode.row - destinationNode.row) * _straightCost
		+ Math.Abs
		(testNode.column - destinationNode.column) * _straightCost;
		return h;
	}
	//2. Euclidean
	private long euclidean(SuperNode testNode, SuperNode destinationNode)
	{
		int vx = destinationNode.column - testNode.column;
		int vy = destinationNode.row - testNode.row;
		long h = (long)(Math.Sqrt(vx * vx + vy * vy) * _straightCost);
		return h;
	}
	//3. Diagonal
	private long diagonal(SuperNode testNode, SuperNode destinationNode)
	{
		long vx
		= Math.Abs(destinationNode.column - testNode.column);
		long vy
		= Math.Abs(destinationNode.row - testNode.row);

		long h;
		if (vx > vy)
		{
			h = (long)(_diagonalCost * vy + _straightCost * (vx - vy));
		}
		else
		{
			h = (long)(_diagonalCost * vx + _straightCost * (vy - vx));
		}
		return h;
	}
}
	/*
	public class CustomComparator implements Comparator<SuperNode> {
		@Override

				public int compare(SuperNode o1, SuperNode o2)
	{

		return Integer.compare((int)o1.finalCost, (int)o2.finalCost);
		//return o1.f.compareTo(o2.f);
	}
	
}

}
*/