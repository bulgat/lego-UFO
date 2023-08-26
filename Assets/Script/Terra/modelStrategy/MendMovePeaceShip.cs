using System.Collections;
using System.Collections.Generic;

using System;

public class MendMovePeaceShip 
{
	public static void moveFiend_MIR(Country Country, List<GridFleet> NameHero_ar,
				   List<Island> Island_ar, List<Country> DispositionCountry_ar,
				   List<GridTileBar> Grid_ar,
				   List<CommandStrategy> CommandStrategy_ar
				   )
	{

		List<GridFleet> DispositionCountryNameHero_ar
		= FiendFleet.GetHeroAll(Country.IdCountry, NameHero_ar);

		foreach (GridFleet gridFleet in DispositionCountryNameHero_ar)
		{
			if (gridFleet.GetTurnDone()) { }
			else
			{
				MendMoveShip.SetMoveFleet(gridFleet);
				// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ.
				if (gridFleet.GetAimPeaceCaravan() == null)
				{
					// get end point caravan.
					// пїЅпїЅпїЅпїЅ пїЅпїЅпїЅ, пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
					List<Point> point_ar = AI_Behavior.GetGlobalIslandArray(Island_ar, gridFleet, DispositionCountry_ar, true);
					var rand = new System.Random();

					//Point point = point_ar[(int)Math.floor(Math.random() * point_ar.size())];
					Point point = point_ar[rand.Next(point_ar.Count)];
					gridFleet.SetAimPeaceCaravan(point);// = point;
														//System.out.println(  "_____  SeaShip imageFlag ==  "+point_ar.size());

				}
				else
				{
					//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ.
					//пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
					Point resultPoint = AI_Behavior.GetPathPoint(gridFleet.GetAimPeaceCaravan(), new Point(gridFleet.SpotX, gridFleet.SpotY),
							gridFleet.GetFlagId(),
							NameHero_ar, Grid_ar, DispositionCountry_ar, gridFleet.GetSea(), Island_ar
							);


					if (resultPoint != null)
					{
						CommandStrategy commandStrategy = new CommandStrategy();
						commandStrategy.GridFleetOldPoint = new Point(gridFleet.SpotX, gridFleet.SpotY);
						commandStrategy.GridFleetNewPoint = new Point((int)resultPoint.X, (int)resultPoint.Y);
						gridFleet.SpotX = (int)resultPoint.X;
						gridFleet.SpotY = (int)resultPoint.Y;
						CommandStrategy_ar.Add(commandStrategy);
					}

					// пїЅпїЅпїЅпїЅпїЅ пїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅ? пїЅпїЅ пїЅпїЅпїЅпїЅ?
					if (gridFleet.SpotX == gridFleet.GetAimPeaceCaravan().X && gridFleet.SpotY == gridFleet.GetAimPeaceCaravan().Y)
					{
						// пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅ. пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ.
						gridFleet.SetAimPeaceCaravan(null); //= null;
					}

				}
			}
		}
	}
}
