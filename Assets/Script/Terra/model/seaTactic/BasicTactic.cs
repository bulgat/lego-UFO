using System.Collections;
using System.Collections.Generic;


public class BasicTactic
{
	private GridFleet heroFiend;
	private GridFleet heroPlayer;
	public int SelectShipFiend = 0;
	public int SelectShipPlayer = 0;

	public BasicTactic() {
		SelectShipFiend = 0;
	SelectShipPlayer = 0;
}

	public GridFleet GetFiendFleet()
	{
		return heroFiend;
	}
	public void SetFiendFleet(GridFleet gridFleet)
	{
		heroFiend = gridFleet;
	}
	public GridFleet GetPlayerFleet()
	{
		return heroPlayer;
	}
	public void SetPlayerFleet(GridFleet gridFleet)
	{
		heroPlayer = gridFleet;
	}
	public void StopBattleVictory(PrototypeHeroDemo prototypeHeroDemo)
	{
		MeleeShip meleeShip = new MeleeShip();

		ButtonEvent model = meleeShip.SetEventEndTactic(
				heroPlayer.GetShipName(),
				heroFiend.GetShipName());

	
		// load scenr
		MapWorldModel.MapWorldModelSingleton().GotoStrateg(model);
	}
}
