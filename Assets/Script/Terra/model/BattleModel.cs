using System.Collections;
using System.Collections.Generic;


public class BattleModel
{
	private static float Upheaval_x = 0;
	private static float Upheaval_y = 0;
	public static int countTurn;
	public static float GetUpheavalX()
	{
		return Upheaval_x;
	}
	public static float GetUpheavalY()
	{
		return Upheaval_y;
	}
	static long _blockTimeAttack;
	static long _tick;
	static long _tickDamage;
	public static bool GetUnBlockTimeAttack()
	{
		return true;
		
		int animCoef = (int)_tick - (int)_tickDamage;
		/*
		Object kol = Main._main._drawBattleView;
		bool battleGo = (kol instanceof BattleBasicView);
		if (battleGo)
		{

		}
		else
		{
			return true;
		}
		*/
		

		if (animCoef > _blockTimeAttack)
		{
			return true;
		}
		return false;
	}
	public static void Init(bool Card)
	{

		//_cardTypeBattle = Card;
		//_modeJrpg = false;
		//_jrpgModel = new JrpgModel();
		//if (_createNewMaze) { }
		//else
		//{
			//_maze = new Maze(Card);
			//_createNewMaze = true;

		//}

	}
	public static void UpheavalTile(float UpheavalX, float UpheavalY)
	{
		Upheaval_x -= (float)UpheavalX;
		Upheaval_y -= (float)UpheavalY;
	}
	public static void WinPlayerBattle(string ChangeScene)
	{
		//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);

		LoadSceneChange.LoadSceneRotation("SampleScene");
		// Battle
		//Main._main.WinPlayerModel(ChangeScene, Main._main._drawBattleView);


	}
	public static void PlayHelp(string model, ButtonEvent kol)
	{

		//PlayMusic(PhraseologySyllable.GetSyllableAngToMusic(Main._main._greatPhraseology.Syllable));
	}
	public static void EventSyllable(string model)
	{

		//_syllable = model;
	 
	}
	public static void StartCard(string ConstantName)
	{

		//Main._main.WinPlayerModel(ConstantName, null);
	}
	public static void PharmacyHero()
	{
		//_player.RemovePharmacy();
		//_player.PharmacyHp(1);
		//PlayMusic(MusicBibleConstant.Pharmacy);
	}
	public static void InitMenuBattle()
	{
		//SoundPlayPiano.PlaySound(MusicBibleConstant.Click);
		//Main._main.InitMenuView();
		LoadSceneChange.LoadSceneRotation("StartMenu");
	}
}
