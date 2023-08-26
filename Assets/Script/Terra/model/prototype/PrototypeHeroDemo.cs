using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PrototypeHeroDemo 
{
	private List<GridFleet> NameHero_ar;

	public void HeroFleetInit()
	{
		this.NameHero_ar = new List<GridFleet>();
	}
	public GridFleet HeroFleetAdd(GridFleet gridFleet)
	{
        this.NameHero_ar.Add(gridFleet);
		return gridFleet;
	}
	public void HeroFleetRemove(GridFleet gridFleet)
	{
        this.NameHero_ar.Remove(gridFleet);
	}
	public void HeroFleetAddAll(List<GridFleet> gridFleet_ar)
	{
        this.NameHero_ar.AddRange(gridFleet_ar);

	}
	public List<GridFleet> GetHeroFleet()
	{
		return this.NameHero_ar;
	}
	public GridFleet GetHeroFleetFirst()
	{
		return this.NameHero_ar[0];
	}
	public int GetNextFleetIdPlayer(int Id,int move,int FlagIdPlayer)
	{
		var fleetPlayerList = this.NameHero_ar.Where(a => a.GetFlagId() == FlagIdPlayer).ToList();
		int index = fleetPlayerList.FindIndex(a => a.GetId() == Id);
        
        index +=move;
        
        if (index < 0) { 
			index = fleetPlayerList.Count() - 1;
        }
        if (index >= fleetPlayerList.Count()) { 
			index = 0;
            
        }

        
        return fleetPlayerList[index].GetId();
    }
	public GridFleet GetFleetWithId(int Id)
	{
		foreach (GridFleet gridFleet in this.NameHero_ar)
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

		foreach (GridFleet gridFleet in NameHero_ar)
		{

			copyHero_ar.Add(gridFleet.Copy());
		}
		return copyHero_ar;
	}
}
