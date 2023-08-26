using System.Collections;
using System.Collections.Generic;

using System;

public class MeleeShip
{
	public static GridFleet _heroFiend;
	public static GridFleet _heroPlayer;

	private static int _countFrame = 0;

	public static ShipUnit _shipOneNamePLayer;
	public static ShipUnit _shipOneNameFiend;

	public static int _timeBattleCount = 99;

	public static int _limitDeadUnit = 0;
	public static int _countDeadUnit = 0;

	public void Launch(//GridFleet heroFiend, 
			//GridFleet shipName_Player

		)
	{
		//_heroFiend = heroFiend;
		//_heroPlayer = shipName_Player;
		_countFrame = 0;
		_timeBattleCount = 0;
		//_limitDeadUnit = (int)Math.floor(Math.random() * 9);
		System.Random rnd = new System.Random();
		_limitDeadUnit = rnd.Next(9);
		_countDeadUnit = 0;

	}
	public void EnterFrame()
	{
		_countFrame++;
		_timeBattleCount++;
		Stream_Run();
	}
	public void ReleaseDead(List<UnitResultTactic> unitResultTactic_ar,
			List<GridCrewScience> BasaPurchaseUnitScience_ar,
			ShipUnit CrewPlayer,
			ShipUnit CrewFiend
			  )
	{

		Robot robot = new Robot();

		foreach (UnitResultTactic unitResultTactic in unitResultTactic_ar)
		{

			if (unitResultTactic.BlockDead)
			{

			}
			else
			{


				// dead ship
				robot.DeadUnit(
						unitResultTactic.UnitIdDead,
						unitResultTactic.UnitIdWin,
							BasaPurchaseUnitScience_ar,
							CrewPlayer,
							CrewFiend
						);
			}
		}
	}

	public List<UnitResultTactic> GetStreamRunFast(
			GridFleet HeroFiend,
			GridFleet HeroPlayer,
			ShipUnit ShipOneNamePLayer,
			ShipUnit ShipOneNameFiend,
			int LimitDeadUnit,
			bool MoveAi,
			bool LongRange
			)
	{

		List<UnitResultTactic> unitResultTactic_ar = new List<UnitResultTactic>();

		// get statistic dead unit fleetShip
		List<int> deadIdUnit_ar = new List<int>();

		int count = 0;
		List<ArmUnit> CrewPLayer_ar = GetShipUnitLife(ShipOneNamePLayer.GetArmUnitArray(), deadIdUnit_ar);
		List<ArmUnit> CrewFiend_ar = GetShipUnitLife(ShipOneNameFiend.GetArmUnitArray(), deadIdUnit_ar);

		while (ShipUnitLife(CrewPLayer_ar, deadIdUnit_ar) && ShipUnitLife(CrewFiend_ar, deadIdUnit_ar))
		{

			if (count <= LimitDeadUnit)
			{


				CrewPLayer_ar = GetShipUnitLife(ShipOneNamePLayer.GetArmUnitArray(), deadIdUnit_ar);
				CrewFiend_ar = GetShipUnitLife(ShipOneNameFiend.GetArmUnitArray(), deadIdUnit_ar);



				UnitResultTactic unitResultTactic = MeleeUnitResult.Add_Melee_Unit(
						BattlePlanetModel.GetBasaPurchaseUnitScience(),
					HeroFiend, HeroPlayer,
					CrewPLayer_ar, CrewFiend_ar,
					MoveAi, LongRange,
					MapWorldModel.GetIslandMemento());

				unitResultTactic_ar.Add(unitResultTactic);
				deadIdUnit_ar.Add(unitResultTactic.UnitIdDead);

				count++;
			}
			else
			{

				break;
			}
			/*
			if(count>20) {
				break;
			}
			*/
		}
		return unitResultTactic_ar;
	}
	public bool ShipUnitLife(List<ArmUnit> Crew_ar, List<int> DeadIdUnit_ar)
	{
		List<ArmUnit> CrewLife_ar = GetShipUnitLife(Crew_ar, DeadIdUnit_ar);

		if (CrewLife_ar.Count > 0)
		{
			return true;
		}
		return false;
	}
	private List<ArmUnit> GetShipUnitLife(List<ArmUnit> Crew_ar, List<int> DeadIdUnit_ar)
	{
		List<ArmUnit> CrewLife_ar = new List<ArmUnit>();
		foreach (ArmUnit armUnit in Crew_ar)
		{
			bool dead = false;
			foreach (int id in DeadIdUnit_ar)
			{
				if (id == armUnit.Id)
				{
					//continue;
					dead = true;
				}
			}
			if (!dead)
			{
				CrewLife_ar.Add(armUnit);
			}
		}

		return CrewLife_ar;
	}
	public void Stream_Run()
	{
		if (_countFrame == 1)
		{
			UnitResultTactic unitResultTactic = MeleeUnitResult.Add_Melee_Unit(
					BattlePlanetModel.GetBasaPurchaseUnitScience(),
					_heroFiend, _heroPlayer,
					_shipOneNamePLayer.GetArmUnitArray(),
					_shipOneNameFiend.GetArmUnitArray(),
					Tactic.GetTactic().MoveAI, Tactic.GetTactic().LongRange,
					MapWorldModel.GetIslandMemento());
		}
		if (_countFrame >= 25)
		{

			// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ.
			// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ-пїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
			if (Tactic.GetTactic().DeadPlayer)
			{

				_shipOneNamePLayer.GetArmUnitArray().RemoveAt(Tactic.GetTactic().Select_Unit_Player);
			}
			else
			{
				_shipOneNameFiend.GetArmUnitArray().RemoveAt(Tactic.GetTactic().Select_Unit_Fiend);
			}

			_countDeadUnit++;
			if (ThereIdMeleeUnit(_shipOneNamePLayer, _shipOneNameFiend))
			{
				if (_countDeadUnit >= _limitDeadUnit)
				{
					// пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ.
					ButtonEvent model = new ButtonEvent();
					model.MoveAI = Tactic.GetTactic().MoveAI;
					//Tactic.GetTactic()._meleeShip = null;
					model.IdHero = -1;

					MapWorldModel.GotoStrateg(model);
				}
			}
			if (ThereIdMeleeUnit(_shipOneNamePLayer, _shipOneNameFiend))
			{

				_countFrame = 0;

			}
			else
			{
				ButtonEvent model = SetEventEndTactic(_shipOneNamePLayer, _shipOneNameFiend);
				MapWorldModel.GotoStrateg(model);


			}


		}
	}
	public ButtonEvent SetEventEndTactic(
			ShipUnit shipNamePlayer,
			ShipUnit shipNameFiend)
	{

		ButtonEvent model = new ButtonEvent();

		if (!Robot.Yes_Refreshment(shipNamePlayer))
		{

			model.IdHero = Tactic.GetTactic().GetPlayerFleet().GetId();
			//System.out.println("p @@@ Get model.IdHero " + shipNamePlayer.GetArmUnitArray().size() + "  ===   " + model.IdHero);
		}

		if (!Robot.Yes_Refreshment(shipNameFiend))
		{

			model.IdHero = Tactic.GetTactic().GetFiendFleet().GetId();
			//System.out.println("f @@@ Get model.IdHero  " + shipNameFiend.GetArmUnitArray().size() + " ===   " + model.IdHero);
		}

		model.MoveAI = Tactic.GetTactic().MoveAI;
		//Tactic.GetTactic()._meleeShip = null;

		return model;
	}

	private bool ThereIdMeleeUnit(ShipUnit shipPLayer, ShipUnit shipFiend)
	{
		if (Robot.Yes_Refreshment(shipPLayer) && Robot.Yes_Refreshment(shipFiend))
		{
			return true;
		}
		return false;
	}
}
