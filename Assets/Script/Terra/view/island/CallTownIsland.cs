using System.Collections;
using System.Collections.Generic;


public class CallTownIsland 
{
    public CallTownIsland() {
        ButtonEvent islandEvent = new ButtonEvent();
        islandEvent.Island = null;

        ControllerButton.EventCall(ControllerConstant.IslandHero, ControllerConstant.IslandHero, islandEvent);
    }
}
