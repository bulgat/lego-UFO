using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PrototypeHeroDemo 
{
	private List<GridFleet> Fleet_ar;

	public void HeroFleetInit()
	{
		this.Fleet_ar = new List<GridFleet>();
	}
	public void Reset()
	{
        this.Fleet_ar.Clear();
    }
	public GridFleet HeroFleetAdd(GridFleet gridFleet)
	{
        this.Fleet_ar.Add(gridFleet);
		return gridFleet;
	}
	public void HeroFleetRemove(GridFleet gridFleet)
	{
        this.Fleet_ar.Remove(gridFleet);
	}
	public void HeroFleetAddAll(List<GridFleet> gridFleet_ar)
	{
        this.Fleet_ar.AddRange(gridFleet_ar);

	}
	public List<GridFleet> GetHeroFleet()
	{
		return this.Fleet_ar;
	}
	public GridFleet GetHeroFleetFirst()
	{
		return this.Fleet_ar[0];
	}
	public int GetNextFleetIdPlayer(int Id,int move,int FlagIdPlayer)
	{
		var fleetPlayerList = this.Fleet_ar.Where(a => a.GetFlagId() == FlagIdPlayer).ToList();
		var index = fleetPlayerList.FindIndex(a => a.GetId() == Id);
		index +=move;
		if (index < 0) { index = fleetPlayerList.Count() - 1; }
        if (index >= fleetPlayerList.Count()) { index = 0; }
		return fleetPlayerList[index].GetId();
    }
	public GridFleet GetFleetWithId(int Id)
	{
		foreach (GridFleet gridFleet in this.Fleet_ar)
		{
			if (gridFleet.GetId() == Id)
			{
				return gridFleet;
			}
		}
		return null;
	}

	public List<GridFleet> HeroFleetCopy()
	{
		List<GridFleet> copyHero_ar = new List<GridFleet>();

		foreach (GridFleet gridFleet in Fleet_ar)
		{

			copyHero_ar.Add(gridFleet.Copy());
		}
		return copyHero_ar;
	}
}
