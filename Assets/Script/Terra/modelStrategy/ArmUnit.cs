using System.Collections;
using System.Collections.Generic;


public class ArmUnit : ArmUnitShip
{
	GridCrewScience _gridCrewScience;
	private BattlePlanetModel _battlePlanetModel;
	public string Name;
	public int Level;
	public int Attack;
	public int Defence;

	public double Speed = 1;

	public string SoundMusic;
	public bool LongRange;


	public ArmUnit(BattlePlanetModel battlePlanetModel, int unit, int customShip):base(battlePlanetModel.GetBasaPurchaseUnitScience()[unit].IdImage)
	{
        _battlePlanetModel = battlePlanetModel;
		_gridCrewScience = battlePlanetModel.GetBasaPurchaseUnitScience()[unit];
		Attack = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].Attack;
		Defence = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].Defence;
		Name = "pi_"+ battlePlanetModel.GetBasaPurchaseUnitScience()[unit].SoundMusic;
		// BasaPurchaseUnitScience_ar[unit].IdImage;

        SetUnit(unit);
		Id = battlePlanetModel.GetIdUnit();
		Speed = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].StrategySpeed;
		SoundMusic = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].SoundMusic;
		LongRange = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].LongRange;
		Sea = battlePlanetModel.GetBasaPurchaseUnitScience()[unit].Sea;

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
		ArmUnit armUnit = new ArmUnit(this._battlePlanetModel, GetUnit(), 0);
		return armUnit;
	}
	public GridCrewScience GetUnitScience()
	{
		return _gridCrewScience;
	}
}
