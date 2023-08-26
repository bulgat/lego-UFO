using System.Collections;
using System.Collections.Generic;


public class ArmUnit : ArmUnitShip
{
	GridCrewScience _gridCrewScience;
	private List<GridCrewScience> basaPurchaseUnitScience_ar;
	public string Name;
	public int Level;
	public int Attack;
	public int Defence;

	public double Speed = 1;

	public string SoundMusic;
	public bool LongRange;


	public ArmUnit(List<GridCrewScience> BasaPurchaseUnitScience_ar, int unit, int customShip):base(BasaPurchaseUnitScience_ar[unit].IdImage)
	{
		this.basaPurchaseUnitScience_ar = BasaPurchaseUnitScience_ar;
		_gridCrewScience = BasaPurchaseUnitScience_ar[unit];
		Attack = BasaPurchaseUnitScience_ar[unit].Attack;
		Defence = BasaPurchaseUnitScience_ar[unit].Defence;
		Name = "pi_"+ BasaPurchaseUnitScience_ar[unit].SoundMusic;
		// BasaPurchaseUnitScience_ar[unit].IdImage;

        SetUnit(unit);
		Id = BattlePlanetModel.UnitId++;
		Speed = BasaPurchaseUnitScience_ar[unit].StrategySpeed;
		SoundMusic = BasaPurchaseUnitScience_ar[unit].SoundMusic;
		LongRange = BasaPurchaseUnitScience_ar[unit].LongRange;
		Sea = BasaPurchaseUnitScience_ar[unit].Sea;

		// ship sea
		/*
		if (BasaPurchaseUnitScience_ar[unit].Sea)
		{
			CritDamage = 0;
			HeartPowerState = 50;
			HeartPower = 50;
		
			this.SetShip(BasaPurchaseUnitScience_ar[unit].IdTypeShip, customShip);
		}
		*/
	}
	public ArmUnit Copy()
	{
		ArmUnit armUnit = new ArmUnit(basaPurchaseUnitScience_ar, GetUnit(), 0);
		return armUnit;
	}
	public GridCrewScience GetUnitScience()
	{
		return _gridCrewScience;
	}
}
