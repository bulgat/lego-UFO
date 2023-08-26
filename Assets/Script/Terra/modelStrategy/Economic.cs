using System.Collections;
using System.Collections.Generic;


public class Economic 
{
	public Economic()
	{
		BattleModel.countTurn = 0;
	}
	public static void Reset()
	{
		BattleModel.countTurn = 0;
	}
	public static void Turn(List<Country> DispositionCountry_ar, List<Island> Island_ar)
	{
		if (BattleModel.countTurn % 10 == 0)
		{
			foreach (Country country in DispositionCountry_ar)
			{
				List<Island> island_ar = ModelStrategy.GetFlagIslandArray(Island_ar, country.IdCountry, false);
				country.Money += island_ar.Count;
			}
		}
		BattleModel.countTurn++;
	}
}
