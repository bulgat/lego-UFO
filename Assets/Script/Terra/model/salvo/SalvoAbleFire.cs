using System.Collections;
using System.Collections.Generic;


public class SalvoAbleFire 
{
	public bool AbleFire(ShipCapsule shipCapsule, int GlobalParamsTimeQuick,
			int GlobalParamsGale, int Distance)
	{



		if (shipCapsule.ShipCannon != null)
		{
			ShipCannon shipCannon = shipCapsule.ShipCannon;

			//System.out.println("TimeQuick=" + shipCannon.TimeQuick + "+" + shipCannon.Charge + " @@  GlobalParamsTimeQuick= " + GlobalParamsTimeQuick + "= Able  =");

			//проверка времени заряжания и дистанции
			if (shipCannon.TimeQuick + shipCannon.Charge < GlobalParamsTimeQuick)
			{



				//Check Distance.... Range
				if (shipCannon.Range >= Distance)
				{

					//проверка поврежений
					if (shipCapsule.Damage == false)
					{
						//а есть ли орудие?

						//Weather
						if (shipCapsule.GoalSurge >= GlobalParamsGale)
						{



							return true;
						}

					}
				}
			}
		}
		return false;
	}
}
