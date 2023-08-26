using System.Collections;
using System.Collections.Generic;


public class CommandStrategy : CommandStrategyView
{
	public enum Type { CaptureIsland, MoveFleet, AttackFleet, CreateFleet }
	private static int idCount = 1;

	public CommandStrategy()
	{
		Id = idCount;
		idCount++;
		LongRange = false;
		AttackPlayer = false;
	}

	public Island CaptureIsland;
	public int OldIslandFlag;
	public Point GridFleetOldPoint;
	public Point GridFleetNewPoint;
	public GridFleet GridFleet;
	public GridFleet GridFleetVictim;
	public Type NameCommand;
	public bool LongRange;
	public int Id;
	public bool AttackPlayer;
	public List<UnitResultTactic> unitResultTactic_ar;
}
