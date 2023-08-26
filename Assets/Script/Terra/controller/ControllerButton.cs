using System.Collections;
using System.Collections.Generic;


public class ControllerButton 
{
	private static bool _blockCommand;


	public ControllerButton()
	{

	}
	public static void EventCallModel(string ConstantName, string ModelName, ButtonEvent EventButton)
	{
		if (ConstantName ==ControllerConstant.DeadArmUnit.ToString())
		{
			ButtonEvent stop = (ButtonEvent)EventButton;

			SeaTactic.GetTactic().DeadArmUnitSeaTactic(stop);
			return;
		}
	}
	public static void EventCall(string ConstantName, string ModelName, ButtonEvent EventButton)
	{

		if (_blockCommand == false) 
		{



			if (BattleModel.GetUnBlockTimeAttack())
			{
				if (ConstantName == ControllerConstant.Turn)
				{
					//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					BattlePlanetModel.BattlePlanetTurn();

					return;
				}


				if (ConstantName ==ControllerConstant.Exit.ToString())
				{

					BattleModel.Init(true);

					return;
				}
				if (ConstantName == ControllerConstant.Tile.ToString())
				{
					ButtonEvent stop = (ButtonEvent)EventButton;

					BattleModel.UpheavalTile(stop.DownMouseX, stop.DownMouseY);
					return;
				}
		
				if (ConstantName == ControllerConstant.DeleteUnit.ToString())
				{
					ButtonEvent stop = (ButtonEvent)EventButton;

					BattlePlanetModel.GotoFragDropArmy();
					return;
				}
				if (ConstantName ==ControllerConstant.Move.ToString())
				{
					// Sea tactic.
					SeaTactic.GetTactic().TurnSeaTactic();
					return;
				}
				if (ConstantName.Equals(ControllerConstant.BuyUnitDialog.ToString()))
				{
					ButtonEvent stop = (ButtonEvent)EventButton;
					IslandModel.BuyUnitDialog(stop);
					return;
				}
				if (ConstantName.Equals(ControllerConstant.AlertDialogBuyUnit.ToString()))
				{
					//IslandModel.BuyUnitDialog();
					ButtonEvent stopIsland = (ButtonEvent)EventButton;
					IslandModel.BuyUnitConfirm(stopIsland);

					return;
				}
				
				if (ConstantName == ControllerConstant.StartBattle)
				{
					BattleModel.WinPlayerBattle(ConstantName);

					return;
				}
				if (ConstantName == ControllerConstant.HelpSyllable)
				{
					BattleModel.PlayHelp(ModelName, EventButton);
					return;
				}
				if (ConstantName == ControllerConstant.Syllable)
				{
					BattleModel.EventSyllable(ModelName);
					EventCall(ModelName, "model", EventButton);
					return;
				}
				//CloseTotalMenu
				if (ConstantName == ControllerConstant.CloseTotalMenu)
				{
					BattleModel.WinPlayerBattle(ConstantName);

					return;
				}
				
				if (ConstantName.Equals(ControllerConstant.CloseJrpgTotalMenu))
				{
					BattleModel.WinPlayerBattle(ConstantName);

					return;
				}
				if (ConstantName == ControllerConstant.StartCard)
				{
					BattleModel.Init(true);
					BattleModel.StartCard(ConstantName);
					return;
				}
				if (ConstantName == ControllerConstant.CardSelect)
				{

					BattleModel.EventSyllable(ModelName);
					EventCall(ModelName, "model", EventButton);
					return;
				}
				if (ConstantName == ControllerConstant.Pharmacy)
				{

					BattleModel.PharmacyHero();
					return;
				}
				if (ConstantName.Equals(ControllerConstant.IslandSelectHero))
				{
					ButtonEvent island = (ButtonEvent)EventButton;
					BattlePlanetModel.SelectIslandFleet(island.Island);
					return;
				}

				if (ConstantName.Equals(ControllerConstant.IslandHero))
				{
					ButtonEvent island = (ButtonEvent)EventButton;

					BattlePlanetModel.GotoIsland(island.Island);

					return;
				}
				if (ConstantName == ControllerConstant.StartMenuInit)
				{
					BattleModel.InitMenuBattle();

					return;
				}
				///// Planet
				if (ConstantName == ControllerConstant.Turn)
				{
					SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					BattlePlanetModel.BattlePlanetTurn();

					return;
				}
				if (ConstantName == ControllerConstant.CloseIsland)
				{
					SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					BattlePlanetModel.GotoPlanetWorld();

					return;
				}
				if (ConstantName == ControllerConstant.BuyIslandPurchaseUnit)
				{
					SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					ButtonEvent buyUnit = (ButtonEvent)EventButton;

					MapWorldModel.BuyUnit(buyUnit);
					return;
				}



				if (ConstantName == ControllerConstant.SelectHeroLeft)
				{
					//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					//ButtonEvent buttonEvent = (ButtonEvent)EventButton;


					//MapWorldModel.SelectHero(buttonEvent);
					MapWorldModel.SelectHeroLeft();

                    return;
				}
				if (ConstantName == ControllerConstant.SelectHeroRight)
				{
					//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					//ButtonEvent buttonEvent = (ButtonEvent)EventButton;


					//MapWorldModel.SelectHero(buttonEvent);
                    MapWorldModel.SelectHeroRight();
                    return;
				}
				if (ConstantName == ControllerConstant.SelectHero)
				{
					//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
					ButtonEvent buttonEvent = (ButtonEvent)EventButton;

					
					MapWorldModel.SelectHero(buttonEvent);
					return;
				}




				if (ConstantName.Equals(ControllerConstant.SeaSelectHero))
				{

					ButtonEvent stop = (ButtonEvent)EventButton;
					SeaTactic.GetTactic().SeaSelectHero(stop);
					return;
				}
				if (ConstantName == ControllerConstant.PathHero)
				{
					ButtonEvent buttonEvent = (ButtonEvent)EventButton;

					MapWorldModel.GotoHero(buttonEvent);
					return;
				}
				if (ConstantName.Equals(ControllerConstant.SeaPathHero))
				{
					ButtonEvent eventSea = (ButtonEvent)EventButton;

					
					SeaTactic.GetTactic().GotoHero(eventSea);
					return;
				}
				if (ConstantName == ControllerConstant.AttackHero)
				{

					ButtonEvent buttonEvent = (ButtonEvent)EventButton;

					MapWorldModel.AttackHero(buttonEvent);
					return;
				}
				if (ConstantName.Equals(ControllerConstant.SeaAttackHero))
				{
					ButtonEvent buttonEvent = (ButtonEvent)EventButton;
					SeaTactic.GetTactic().AttackHero(buttonEvent);
					return;
				}

				// default
				throw new System.Exception("ERROR!!");
				//BattleModel.SyllableModel(ConstantName);
			}
			else
			{
				//System.out.println("ControllerButton=BlockTimeAttack=");
			}
		}
		else
		{
			//System.out.println("ControllerButton=SetBlock=");
		}
	}
	public static void SetCommandPerform(int CommandId)
	{
		MapWorldModel.PickUpCommandCaptureIsland(CommandId);
	}
	public static void SetBlock()
	{
		_blockCommand = true;
	}
	public static void UnlockBlock()
	{
		_blockCommand = false;
	}
}
