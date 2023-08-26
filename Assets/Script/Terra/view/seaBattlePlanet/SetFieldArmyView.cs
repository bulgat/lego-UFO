using System.Collections;
using System.Collections.Generic;


public class SetFieldArmyView 
{
	public List<UnitTacticBasic> _unitTacticBasic_ar;
	public void InitUnitToField( 
			int widthStage, int HeightStage,
			ShipUnit shipPlayer, bool PlayerLeft, float WidthPanelBattlePlanet, bool test)
	{
		if (test)
		{
			//SetTestField( widthStage, HeightStage, 6, WidthPanelBattlePlanet);
		}
		
		_unitTacticBasic_ar = new List<UnitTacticBasic>();

		

		// Debug tactic
		BattlePlanetView _battlePlanetView = new BattlePlanetView();
		_battlePlanetView = BattlePlanetView.GetBattlePlanetViewSingleton();
		MapWorldModel.StartGame();
var kol = MapWorldModel._prototypeHeroDemo.GetHeroFleet();


		//new Tactic(MapWorldModel._prototypeHeroDemo.GetFleetWithId(1), MapWorldModel._prototypeHeroDemo.GetFleetWithId(2), true, false);

		//new Tactic(kol[0], kol[1], true, false);


		//End Debug tactic



		//SeaTactic seaTactic = new SeaTactic(kol[0], kol[1],1);
		SeaTactic seaTactic = SeaTactic.GetTactic();
		
		
		
		//_actor_ar = new ArrayList<GroupActor>();
		SetUnitToField( widthStage, HeightStage,
				 seaTactic.GetPlayerFleet().GetShipName(),
				 true,
				 _unitTacticBasic_ar, 6, WidthPanelBattlePlanet);

		SetUnitToField(widthStage, HeightStage, 
				seaTactic.GetFiendFleet().GetShipName(),
				false,
				_unitTacticBasic_ar, 6, WidthPanelBattlePlanet);

	
	}
	public void SetUnitToField(int widthStage, int HeightStage,
			ShipUnit shipPlayer,
			bool PlayerLeft,
			List<UnitTacticBasic> UnitTacticBasic_ar,
			int DividerField,
			float WidthPanelBattlePlanet)
	{

		GridCrewScience scienceUnit;
		
		for (int i = shipPlayer.GetArmUnitArray().Count - 1; i >= 0; i--)
		{
			
			
			
			scienceUnit = BattlePlanetModel.GetBasaPurchaseUnitScience()[shipPlayer.GetArmUnitArray()[i].GetUnit()];

			UnitTacticSea unitTactic = new UnitTacticSea();

			//List<Texture> ImageUnitList = UnitTexture.GetImageUnit(null, shipPlayer.GetArmUnitArray()[i].GetUnit());

			

			unitTactic.SetUnitTactic(
					i + 1,
					widthStage,
					HeightStage,
					GetProportionScene(scienceUnit, widthStage, 1, DividerField),
					PlayerLeft,
					shipPlayer.GetArmUnitArray()[i].Id,
					scienceUnit.SoundMusic,
					null,
					//UnitTexture.GetExplode(null),
					shipPlayer.GetArmUnitArray()[i],
					DividerField,
					WidthPanelBattlePlanet
					);
					
/*
			UnitTacticBasic_ar.add(unitTactic);*/
		}
		
	}
	public Point GetProportionScene(GridCrewScience scienceUnit, int widthStage, float proportion, int NumPortion)
	{
		float maxWidth = widthStage / NumPortion;
		return new Point(
				(scienceUnit.WidthUnit * maxWidth) / 200,
				(scienceUnit.HeightUnit * maxWidth) / 200);
	}
	public UnitTacticBasic GetUnitTactic(List<UnitTacticBasic> BattleTactic_ar, int Id) {
		foreach (UnitTacticBasic unit in BattleTactic_ar)
		{
			if (unit.GetId() == Id)
			{
				return unit;
			}
		}
		return null;
	}
	public void PerformCommandSea(CommandStrategy commandStrategy, int widthStage, int HeightStage, SeaTactic seaTactic)
	{

		seaTactic.PerformTacticCommand(commandStrategy.Id);


		return;

	}
}
