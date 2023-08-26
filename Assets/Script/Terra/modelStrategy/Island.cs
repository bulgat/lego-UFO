using System.Collections;
using System.Collections.Generic;


public class Island : BasicTile
{
	public Island(string name, int spotX, int spotY, int race, bool castle, int flagId)
	{
        this.Name = name;
		this.SpotX = spotX;
		this.SpotY = spotY;
		this.Race = race;
		this.Castle = castle;
		this.FlagId = flagId;
	}
	public Island GetCopy()
	{
		return new Island(Name, SpotX, SpotY, Race, Castle, FlagId);
	}
	public int GetFlagId() {
		return FlagId;
	}

	public string Name;
	public int Race;
	public bool Castle;
	public int FlagId;
	public int Id;
}
