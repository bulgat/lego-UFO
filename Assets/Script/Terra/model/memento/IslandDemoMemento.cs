using System.Collections;
using System.Collections.Generic;


public class IslandDemoMemento 
{
	private List<Island> Island_ar { get; set; }
	private int _id = 1;

	public IslandDemoMemento()
	{
		this.Island_ar = new List<Island>();
	}
	public List<Island> GetIslandArray()
	{
		return Island_ar;

	}
	public Island GetIslandWithId(int Id)
	{
		foreach (Island island in Island_ar)
		{
			if (island.Id == Id)
			{
				return island;
			}
		}
		return null;
	}
	public List<Island> GetCopyIslandArray()
	{
		List<Island> copyIsland_ar = new List<Island>();
		foreach (Island island in Island_ar)
		{
			copyIsland_ar.Add(island.GetCopy());
		}
		return copyIsland_ar;
	}
	public void SaveChangeIslandArray(List<Island> copyIsland_ar)
	{
		this.Island_ar = copyIsland_ar;

	}
	public void AddIsland(Island island)
	{
		if (null == island)
		{
			throw new System.Exception("Not Island!");
		}

		island.Id = _id;
		Island_ar.Add(island);
		_id++;
	}
}
