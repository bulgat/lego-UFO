using System.Collections;
using System.Collections.Generic;


public class AI_move 
{
	public static Point Operate(
			List<GridFleet> NameHero_ar,
			GridFleet gridFleet,
			List<GridTileBar> Grid_ar,
			List<Island> Island_ar,
			List<Country> DispositionCountry_ar
			)
	{

		// operate.
		return AI_Behavior.TacticSearchIslandAndHero(NameHero_ar,
				gridFleet, Grid_ar, Island_ar, DispositionCountry_ar);
	}
}
