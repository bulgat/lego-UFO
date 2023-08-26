using System.Collections;
using System.Collections.Generic;


public class IslandModel 
{
	public static string _buyUnitDialog;

	public bool GetTypeIslandSea()
	{

		Island isl = BattlePlanetModel.SelectIsland;

		if (isl != null)
		{
			List<GridTileBar> gridTile_ar = BattlePlanetModel.GetGridTileList();

			List<Point> mapFlagIsland_ar = CoordinateSearch.GetMapFlagIslandArray();

			foreach (Point point in mapFlagIsland_ar)
			{

				Point pointIsl = new Point(point.X + isl.SpotX, point.Y + isl.SpotY);

				if (AI_Behavior_Existence.AllowPointMap(BattlePlanetModel.GetShoalSeaBasa_ar(), pointIsl))
				{

					GridTileBar oneGrid = AI_Behavior_Existence.GetOneGrid(gridTile_ar,
							(int)pointIsl.X, (int)pointIsl.Y);



					if (oneGrid.Terrain == BattlePlanetModel.ObstacleSeaMap)
					{

						return true;
					}
				}
			}
		}
		return false;
	}
	public static void BuyUnitDialog(ButtonEvent buttonEvent)
	{


		

		if (GetAllowBuyUnit(buttonEvent.Island.FlagId, buttonEvent.UnitId, false) == false)
		{
			//not money
			_buyUnitDialog = "E DFC YTLJCNFNJXYJ LTYTU YF GJREGRE >YBNF!";
		}
		else
		{
			_buyUnitDialog = "{JNBNT REGBNM >YBN?";
		}
	}
	private static bool GetAllowBuyUnit(int FlagId, int UnitId, bool TakeAway)
	{
		Country country = MapWorldModel.GetCountCountry(FlagId);
		//System.out.println(" @@@@@@@ Alert BuyUnit  __ unit  = " + country.Money);
		if (TakeAway)
		{
			MapWorldModel.TakeAwayMoney(country, UnitId);
		}

		return MapWorldModel.EnoughMoneyOnUnit(country, UnitId);
	}

	public static void BuyUnitConfirm(ButtonEvent buttonEvent)
	{

		//System.out.println("  0   = not money Island   =   " + buttonEvent.NameEvent);
		if (buttonEvent.NameEvent == "false")
		{
			return;
		}
		if (GetAllowBuyUnit(buttonEvent.Island.FlagId, buttonEvent.UnitId, false) == false)
		{
			//not money

	
			return;
		}
		// buy unit.

		GridFleet gridFleet = ModelStrategy.SearchHeroOne(BattlePlanetModel.SelectIsland.SpotX,
				 BattlePlanetModel.SelectIsland.SpotY,
				 MapWorldModel._prototypeHeroDemo.GetHeroFleet(),
				 BattlePlanetModel.SelectIsland.FlagId, false);

		//System.out.println(buttonEvent + " ###  Ta gridFleet = " + gridFleet);




		if (gridFleet == null)
		{
			GetAllowBuyUnit(buttonEvent.Island.FlagId, buttonEvent.UnitId, true);
			MapWorldModel._prototypeHeroDemo.HeroFleetAdd(
					gridFleet = ModelStrategy.GetFleetFast(BattlePlanetModel.SelectIsland.SpotX, BattlePlanetModel.SelectIsland.SpotY,
							BattlePlanetModel.SelectIsland.FlagId, InitGlobalParams.GetOfferNameHero(),
							buttonEvent.UnitId,
							BattlePlanetModel.GetBasaPurchaseUnitScience(), true, 0));
			BattlePlanetModel.SetSelectHeroId (gridFleet.GetId());
			return;
		}
		else
		{



			//gridFleet
			if (gridFleet.GetSea())
			{
				if (gridFleet.GetShipNameFirst().GetArmUnitArray().Count >= 6)
				{
					_buyUnitDialog = "RJKBXTCNDJ >YBNJD D JNHZLT <ELTN GHTDSITYJ";
					return;
				}
				GetAllowBuyUnit(buttonEvent.Island.FlagId, buttonEvent.UnitId, true);
				ModelStrategy.FleetAddArmFast(gridFleet, buttonEvent.UnitId,
						BattlePlanetModel.GetBasaPurchaseUnitScience(), 0);
			}
		}


	}
	public static void ResetBuyUnitDialog()
	{
		_buyUnitDialog = null;
	}
}
