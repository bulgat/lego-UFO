using UnityEngine;
using System.Collections;
using RTS;
using SimpleJSON;

public class ControllerGlobal {


    public ControllerGlobal() {
        EventListeren.eventListerenEvent += onTurn;
    }

    public void StartLevel(int select)
    {
        var I = new JSONClass();
        I[CommandState.InitGameLevel.ToString()] = select.ToString();
        EventListeren.eventDispatchEvent(CommandState.InitGameLevel.ToString(), I.ToString());

        // Блокируем скролл.
        //EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(), "I".ToString());
    }



   void onTurn (string isPower,string obj) {

		//if (isPower == CommandState.Turn.ToString ()) {
		//	EventListeren.eventDispatchController(CommandState.Turn.ToString(),"");
		//}
		if (isPower == CommandState.ClickPlayerShip.ToString ()) {

			EventListeren.eventDispatchController(CommandState.ClickPlayerShip.ToString(),"");
		}
		if (isPower == CommandState.ClickTile.ToString ()) {

			EventListeren.eventDispatchController(CommandState.ClickTile.ToString(),obj);
		}
		if (isPower == CommandState.BuyShip.ToString ()) {
	
			EventListeren.eventDispatchController(CommandState.BuyShip.ToString(),obj);
		}
		if (isPower == CommandState.BlockScroll.ToString ()) {

			EventListeren.eventDispatchController(CommandState.BlockScroll.ToString(),obj);
		}
		if (isPower == CommandState.unBlockScroll.ToString ()) {

			EventListeren.eventDispatchController(CommandState.unBlockScroll.ToString(),obj);
		}
		if (isPower == CommandState.BombPlanet.ToString ()) {

			EventListeren.eventDispatchController(CommandState.BombPlanet.ToString(),obj);
		}
		if (isPower == CommandState.PlanetChooter.ToString ()) {

			EventListeren.eventDispatchController(CommandState.PlanetChooter.ToString(),obj);
		}
		if (isPower == CommandState.PlanetLanding.ToString ()) {

			EventListeren.eventDispatchController(CommandState.PlanetLanding.ToString(),obj);
		}
		if (isPower == CommandState.GotoPlanet.ToString ()) {
			
			EventListeren.eventDispatchController(CommandState.GotoPlanet.ToString(),obj);
		}
		if (isPower == CommandState.ClickFleet.ToString ()) {
			EventListeren.eventDispatchController(CommandState.ClickFleet.ToString(),obj);
		}
		if (isPower == CommandState.LeftChangeShipFleet.ToString ()) {
			EventListeren.eventDispatchController(CommandState.LeftChangeShipFleet.ToString(),obj);
		}
		if (isPower == CommandState.RightChangeShipFleet.ToString ()) {
			EventListeren.eventDispatchController(CommandState.RightChangeShipFleet.ToString(),obj);
		}
        if (isPower == CommandState.InitGameLevel.ToString())
        {
            
            EventListeren.eventDispatchController(CommandState.InitGameLevel.ToString(), obj);
        }
        if (isPower == CommandState.Message.ToString())
        {
            EventListeren.eventDispatchController(CommandState.Message.ToString(), obj);
        }
        if (isPower == CommandState.CameraSetUpBattle.ToString())
        {
            EventListeren.eventDispatchController(CommandState.CameraSetUpBattle.ToString(), obj);
        }
        if (isPower == CommandState.PlanetPanel.ToString())
        {
            EventListeren.eventDispatchController(CommandState.PlanetPanel.ToString(), obj);
        }
        if (isPower == CommandState.BattleInterface.ToString())
        {
            EventListeren.eventDispatchController(CommandState.BattleInterface.ToString(), obj);
        }
        if (isPower == CommandState.InitCustomGameLevel.ToString())
        {
            EventListeren.eventDispatchController(CommandState.InitCustomGameLevel.ToString(), obj);
        }
        if (isPower == CommandState.MessageGlobalWin.ToString())
        {
            EventListeren.eventDispatchController(CommandState.MessageGlobalWin.ToString(), obj);
        }
        if (isPower == CommandState.DestroyGameLevel.ToString())
        {
            EventListeren.eventDispatchController(CommandState.DestroyGameLevel.ToString(), obj);
        }
        if (isPower == CommandState.InitStickGameLevel.ToString())
        {
            EventListeren.eventDispatchController(CommandState.InitStickGameLevel.ToString(), obj);
        }
        
        if (isPower == CommandState.GreetingPlayerMenu.ToString())
        {
            EventListeren.eventDispatchController(CommandState.GreetingPlayerMenu.ToString(), obj);
        }
        

    }

}
