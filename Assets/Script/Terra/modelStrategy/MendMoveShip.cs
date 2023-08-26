using System.Collections;
using System.Collections.Generic;

public class MendMoveShip 
{
	public static AttackMoveFleet PlaceFiendX(
					GridFleet gridFleet,
					List<GridFleet> NameHero_ar,
					List<GridTileBar> Grid_ar,
					List<Island> Island_ar,
					List<Country> DispositionCountry_ar,
					List<CommandStrategy> CommandStrategy_ar,
					ArmUnit ArmUnitFleet,
					int GlobalParamsTimeQuick, int GlobalParamsGale
					)
	{

		gridFleet.Strateg_Memory_BasaSpotX = gridFleet.SpotX;
		gridFleet.Strateg_Memory_BasaSpotY = gridFleet.SpotY;

		bool contact = true;
		if (contact)
		{

			for (int dSpeed = 0; dSpeed < gridFleet.GetPowerReserve(); dSpeed++)
			{
				SetMoveFleet(gridFleet);



				//Operate 
				Point resultPoint = AI_move.Operate(NameHero_ar,
						gridFleet, Grid_ar, Island_ar, DispositionCountry_ar);
				GridFleet fleetVictim;
				if (resultPoint != null)
				{

					fleetVictim = GetFleetVictim(NameHero_ar, resultPoint);
					Point gridFleetOldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);

					if (fleetVictim != null)
					{
						// get firstfleet.
						return GetAttackMoveFleet(fleetVictim, false, null);

					}
					else
					{

						if (ArmUnitFleet == null)
						{


							// LongRange
							// attack fleet is far.
							if (gridFleet.GetRange())
							{
								Point pointLongRange = AI_TacticSearch.GetNearTacticHero(NameHero_ar,
										gridFleet,
										DispositionCountry_ar, CoordinateSearch.GetXmapNear(true));
								// attack fleet with far range.

								if (pointLongRange != null)
								{
									fleetVictim = GetFleetVictim(NameHero_ar, pointLongRange);
									return GetAttackMoveFleet(fleetVictim, true, null);


								}
							}
						}
						else
						{
							//dinamic tactic long range
							Point pointLongRange = AI_TacticSearch.GetNearTacticHero(NameHero_ar,
									gridFleet,
									DispositionCountry_ar, CoordinateSearch.GetXmapNear(true));
							if (pointLongRange != null)
							{
								/*
								TimeSalvoAppendHit timeSalvoAppendHit = new TimeSalvoAppendHit ();

								int Distance = (int)ModelStrategy.GetDistance(
										new Point(gridFleet.SpotX,gridFleet.SpotY),
										pointLongRange);

								ArrayList<ShipCapsule> cannonAbleList=timeSalvoAppendHit.GetCannonAbleList(Distance, ArmUnitFleet.ShipCapsuleList,
										GlobalParamsTimeQuick,GlobalParamsGale);
								*/
								/*
								ArrayList<ShipCapsule> cannonAbleList=new MendMoveAbleFire().GetAbleFireWithDistance(gridFleet,
										pointLongRange,ArmUnitFleet,
										GlobalParamsTimeQuick,GlobalParamsGale
										);
								*/
								//if(cannonAbleList.size()>0) {
								if (new MendMoveAbleFire().DetermineAbleFire(gridFleet,
										pointLongRange, ArmUnitFleet,
										GlobalParamsTimeQuick, GlobalParamsGale
										))
								{
									fleetVictim = GetFleetVictim(NameHero_ar, pointLongRange);
									return GetAttackMoveFleet(fleetVictim, true, null);
								}
								//}

							}
						}

						// move fleet

						CommandStrategy_ar.Add(GetCommandMoveFleet(gridFleetOldPoint,
								resultPoint, gridFleet));
					}


				}

				//attack fleet is neighborn
				{
					fleetVictim = null;
					Point pointLongRange = AI_TacticSearch.GetNearTacticHero(NameHero_ar, gridFleet,
							DispositionCountry_ar, CoordinateSearch.GetMapFlagIslandArray());

					if (pointLongRange != null)
					{

						fleetVictim = GetFleetVictim(NameHero_ar, pointLongRange);

						return GetAttackMoveFleet(fleetVictim, false, resultPoint);
					}

				}

				// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
				// Get not our. get fiend island.
				CaptureSeizureIsland.CaptureIsland(Island_ar, gridFleet,
						NameHero_ar,
						DispositionCountry_ar, CommandStrategy_ar);


				fleetVictim = GetFleetVictimSpecial(gridFleet,
							NameHero_ar, CommandStrategy_ar);
				// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅ?
				if (fleetVictim != null)
				{

					GridFleet fleetVictimStrange = SelectHeroMap.PuttingShadeAttack(NameHero_ar, gridFleet);

					if (fleetVictimStrange != null)
					{
						return GetAttackMoveFleet(fleetVictimStrange, false, null);

					}

				}

			}
		}
		return null;
	}
	
	public static AttackMoveFleet GetAttackMoveFleet(GridFleet fleetVictim,
			bool LongRange, Point PlacePredator)
	{
		AttackMoveFleet attackMoveFleet = new AttackMoveFleet();
		if (fleetVictim == null)
		{
			//throw new Exception("error GetAttackMoveFleet() fleetVictim == null");
		}
		attackMoveFleet.Fleet = fleetVictim;
		attackMoveFleet.LongRange = LongRange;
		if (PlacePredator != null)
		{
			attackMoveFleet.PlacePredator = PlacePredator;
		}
		return attackMoveFleet;
	}

	public static CommandStrategy GetCommandMoveFleet(Point gridFleetOldPoint, Point resultPoint,
			GridFleet gridFleet)
	{
		CommandStrategy commandStrategy = new CommandStrategy();
		// old
		commandStrategy.GridFleetOldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);

		// move fleet
		gridFleet.SpotX = (int)resultPoint.X;
		gridFleet.SpotY = (int)resultPoint.Y;
		commandStrategy.GridFleetNewPoint = new Point((int)resultPoint.X, (int)resultPoint.Y);
		commandStrategy.GridFleet = gridFleet;
		commandStrategy.NameCommand = CommandStrategy.Type.MoveFleet;
		return commandStrategy;
	}
	private static GridFleet GetFleetVictim(List<GridFleet> NameHero_ar, Point resultPoint)
	{
		List<GridFleet> hereinHero_ar =
				FiendFleet.HeroAllCoordinateCoincidence(
						(int)resultPoint.X,
						(int)resultPoint.Y, NameHero_ar);
		if (hereinHero_ar.Count > 0)
		{
			return hereinHero_ar[0];
		}
		return null;
	}

	public static GridFleet GetFleetVictimSpecial(GridFleet gridFleet,
			List<GridFleet> NameHero_ar, List<CommandStrategy> CommandStrategy_ar)
	{
		GridFleet fleetVictim = SelectHeroMap.PuttingShadeAttack(NameHero_ar, gridFleet);
		if (fleetVictim != null)
		{
			CommandStrategy commandStrategy = new CommandStrategy();
			commandStrategy.GridFleetOldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);
			commandStrategy.GridFleetNewPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);
			commandStrategy.GridFleet = gridFleet;
			commandStrategy.GridFleetVictim = fleetVictim;
			commandStrategy.NameCommand = CommandStrategy.Type.AttackFleet;
			CommandStrategy_ar.Add(commandStrategy);
		}
		return fleetVictim;
	}

	public static void SetMoveFleet(GridFleet gridFleet)
	{
		gridFleet.SetTurnDone(true); //= true;
	}
}
