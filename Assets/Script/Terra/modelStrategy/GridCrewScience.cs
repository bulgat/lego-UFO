using System.Collections;
using System.Collections.Generic;


public class GridCrewScience : GridCrewScienceShip
{
	public string Name { get; set; }
    public string NameImage { get; set; }
    public GridCrewScience(
			int idImage,
			int attack,
			int defence,
			int bonusAttack,
			int bonusDefence,
			int widthUnit,
			int heightUnit,

			string Name,
			string NameImage,
			double minSpeed,
			double speed,
			int strategSpeed,
			bool tacticStopFire,
			string soundMusic,
			string soundMove,
			bool longRange,
			int cost,
			bool sea,
			int idTypeShip
			)
	{
		this.IdImage = idImage;

		Attack = attack;
		Defence = defence;
		BonusAttack = bonusAttack;
		BonusDefence = bonusDefence;
		WidthUnit = widthUnit;
		HeightUnit = heightUnit;
	
		this.Name = Name;
		this.NameImage = NameImage;
		MinSpeed = minSpeed;
		Speed = speed;
		StrategySpeed = strategSpeed;
		TacticStopFire = tacticStopFire;
		SoundMusic = soundMusic;
		SoundMove = soundMove;
		LongRange = longRange;
		this.Cost = cost;


		Sea = sea;
		IdTypeShip = idTypeShip;
	}
	public int BonusAttack;
	public int BonusDefence;
	public int Attack;
	public int Defence;
	public int WidthUnit;
	public int HeightUnit;

	//public int ScienceId;
	public double MinSpeed;
	public double Speed;
	public bool TacticStopFire;
	public int StrategySpeed;
	public string SoundMusic;
	public string SoundMove;
	public int Cost = 1;
	public bool LongRange;
	public int IdImage;
	public bool Sea;
}
