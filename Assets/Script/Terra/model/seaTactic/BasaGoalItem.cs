using System.Collections;
using System.Collections.Generic;


public class BasaGoalItem 
{
	public BasaGoalItem(int goalX, int goalY, bool scale)
	{
		GoalX = goalX;
		GoalY = goalY;
		Scale = scale;
	}
	public int GoalX;
	public int GoalY;
	public bool Scale;
}
