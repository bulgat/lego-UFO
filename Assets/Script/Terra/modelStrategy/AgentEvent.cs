using System.Collections;
using System.Collections.Generic;


public class AgentEvent
{
	public static ButtonEvent GetButtonEventModelMeeleeFleet(GridFleet heroPlayer,
			GridFleet gridFleet,
			bool MoveAI, bool LongRange)
	{
		ButtonEvent buttonEvent = new ButtonEvent();
		buttonEvent.SpotX = heroPlayer.SpotX;
		buttonEvent.SpotY = heroPlayer.SpotY;

		buttonEvent.IdHeroFiend = gridFleet.GetId();
		buttonEvent.IdHeroPlayer = heroPlayer.GetId();
		buttonEvent.MoveAI = MoveAI;
		buttonEvent.LongRange = LongRange;
		return buttonEvent;
	}
}
