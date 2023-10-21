using System.Collections;
using System.Collections.Generic;
using ZedAngular.Model.Terra.scenario;

public class IslandModel
{
	public static string _buyUnitDialog;

	public bool GetTypeIslandSea()
	{

		Island isl = BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland;

		if (isl != null)
		{
			List<GridTileBar> gridTile_ar = BattlePlanetModel.GetBattlePlanetModelSingleton().GetGridTileList();

			List<Point> mapFlagIsland_ar = CoordinateSearch.GetMapFlagIslandArray();

			foreach (Point point in mapFlagIsland_ar)
			{

				Point pointIsl = new Point(point.X + isl.SpotX, point.Y + isl.SpotY);

				if (AI_Behavior_Existence.AllowPointMap(BattlePlanetModel.GetBattlePlanetModelSingleton().GetShoalSeaBasa_ar(), pointIsl))
				{

					GridTileBar oneGrid = AI_Behavior_Existence.GetOneGrid(gridTile_ar,
							(int)pointIsl.X, (int)pointIsl.Y);



					if (oneGrid.Terrain == BattlePlanetModel.GetBattlePlanetModelSingleton().ObstacleSeaMap)
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
		Country country = MapWorldModel.MapWorldModelSingleton().GetCountCountry(FlagId);
		//System.out.println(" @@@@@@@ Alert BuyUnit  __ unit  = " + country.Money);
		if (TakeAway)
		{
			MapWorldModel.MapWorldModelSingleton().TakeAwayMoney(country, UnitId);
		}

		return MapWorldModel.MapWorldModelSingleton().EnoughMoneyOnUnit(country, UnitId);
	}

	public static void BuyUnitConfirm(ButtonEvent buttonEvent)
	{

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
		GridFleet gridFleet = ModelStrategy.SearchHeroOne(BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.SpotX,
				 BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.SpotY,
                 BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.GetHeroFleet(),
				 BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.FlagId, false);
		if (gridFleet == null)
		{
			GetAllowBuyUnit(buttonEvent.Island.FlagId, buttonEvent.UnitId, true);
            BattlePlanetModel.GetBattlePlanetModelSingleton()._prototypeHeroDemo.HeroFleetAdd(
					gridFleet = ModelStrategy.GetFleetFast(BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.SpotX, BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.SpotY,
							BattlePlanetModel.GetBattlePlanetModelSingleton().SelectIsland.FlagId,
                            new CreateNameHero().GetOfferNameHero(),
							buttonEvent.UnitId,
							BattlePlanetModel.GetBattlePlanetModelSingleton(), true, 0));
			BattlePlanetModel.GetBattlePlanetModelSingleton().SetSelectHeroId (gridFleet.GetId());
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
						BattlePlanetModel.GetBattlePlanetModelSingleton(), 0);
			}
		}


	}
	public static void ResetBuyUnitDialog()
	{
		_buyUnitDialog = null;
	}
}
