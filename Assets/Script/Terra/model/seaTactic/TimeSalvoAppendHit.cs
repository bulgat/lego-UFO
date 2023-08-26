using System.Collections;
using System.Collections.Generic;

using System;

public class TimeSalvoAppendHit
{
	private List<OccurHit> OccurHitList;




	public List<ImprintVolley> CannonSalvoCount(
			ArmUnitShip armUnitShipHeroPlayer,
			 int Distance,
			 ArmUnitShip armUnitShipHeroFiend,
			 int GlobalParamsTimeQuick,
			 int GlobalParamsGale
			 )
	{

		//int GlobalParamsGale=0;
		int globalParamsWeatherPresent = 0;
		int globalParamsSpeedAimBonus = 20;
		int globalParamsSizeAimBonus = 4;
		int Exact_Crew_Module = BehaviourProperty();
		List<OccurHit> salvoOccurHitList = new List<OccurHit>();
		OccurHitList = new List<OccurHit>();
		List<ImprintVolley> imprintVolleyBasa = new List<ImprintVolley>();
		List<AffectHit> AffectHit_ar = new List<AffectHit>();

		List<ShipCapsule> ShipCapsuleAbleFireList = GetCannonAbleList(Distance,
				armUnitShipHeroPlayer.ShipCapsuleList, GlobalParamsTimeQuick, GlobalParamsGale);


		//запуск функции осматривающей каждую клетку игрока
		foreach (ShipCapsule shipCapsule in ShipCapsuleAbleFireList)
		{

			//if (new SalvoAbleFire().AbleFire(shipCapsule, GlobalParamsTimeQuick,
			//		GlobalParamsGale, Distance) == true)
			//{

			SaveSalvoQuick(shipCapsule.ShipCannon, GlobalParamsTimeQuick);


			//Самая большая пушка будет выводится на экран



			//Рандом попала ли в борт орудие находящее в данной клетке корабля Игрока попадание в борт
			int Affirmative = new SalvoRandom().RandomDistance(Distance) + new SalvoWeather().RandomWeather(globalParamsWeatherPresent) +
			SpeedAim(armUnitShipHeroPlayer, globalParamsSpeedAimBonus) + SizeAim(armUnitShipHeroPlayer, globalParamsSizeAimBonus);

			var rand = new System.Random();

			//Affirmative = (int)Math.floor(Math.random() * Affirmative);
			Affirmative = rand.Next(Affirmative);

			int Unfavourable = shipCapsule.ShipCannon.Exact + Exact_Crew_Module;

			//Unfavourable = (int)Math.floor(Math.random() * Unfavourable);
			Unfavourable = rand.Next(Unfavourable);

			int HITFIEND = Affirmative - Unfavourable;

			//проверка есть ли и сколько орудий находится в данной клетки корабля игрока

			OccurHit occurHit = new OccurHit(0, false);
			salvoOccurHitList.Add(occurHit);
			//timeSalvo.TIMESALVO_APPEND_HIT.OccurHitVolley.push({Nature:0,Within:0,Flow:false,adress:BAmount});

			ImprintVolley imprintVolley = new ImprintVolley();
			imprintVolley.CannonType = shipCapsule.ShipCannon.TypeCannon;

			//вычитание из хранилища боеприпасов потраченных на выстрел боеприпасов потраченных орудием*на их кол-во, находящегося в данной клетке;
			armUnitShipHeroPlayer.FalconetSupply -= shipCapsule.ShipCannon.Ammunition;

			//System.out.println(armUnitShipHeroPlayer.GetTypeShip() + "  @@@@@ up __ unit TypeCannon= " + shipCapsule.ShipCannon.TypeCannon);

			if (HITFIEND <= 0)
			{

				//ОРУДИЕ ПОПАЛО!! начинается расчет какое орудие, какой у нее расход, его вред

				AffectHit affectHit = TakenHitReckoning(armUnitShipHeroFiend, shipCapsule.ShipCannon,
						 Distance);
				//заодно записать время выстрела;
				AffectHit_ar.Add(affectHit);
				imprintVolley.AffectHit = affectHit;
				//System.out.println(" HIT = " + affectHit.Nature + "   affectHit=" + affectHit.OccurHit.Within);
			}
			imprintVolleyBasa.Add(imprintVolley);








			//}

		}
	
		return imprintVolleyBasa;
	}
	public List<ShipCapsule> GetCannonAbleList(int Distance, List<ShipCapsule> ShipCapsuleList,
			int GlobalParamsTimeQuick, int GlobalParamsGale)
	{

		List<ShipCapsule> ShipCapsuleAbleFireList = new List<ShipCapsule>();

		//запуск функции осматривающей каждую клетку игрока
		if (ShipCapsuleList != null)
		{
			foreach (ShipCapsule shipCapsule in ShipCapsuleList)
			{
				if (new SalvoAbleFire().AbleFire(shipCapsule, GlobalParamsTimeQuick,
						GlobalParamsGale, Distance) == true)
				{
					ShipCapsuleAbleFireList.Add(shipCapsule);
				}
				//shipCapsule.ShipCannon.TypeCannon;
			}
		}
		return ShipCapsuleAbleFireList;
	}


	//Management
	public int BehaviourProperty()
	{

		int ExactManagement = 0;

		return ExactManagement;
	}
	public int SizeAim(ArmUnitShip armUnitShipHeroPlayer, int globalParamsSizeAimBonus)
	{
		int SizeGoal = armUnitShipHeroPlayer.SizeAim;
		SizeGoal = 100 - SizeGoal;
		SizeGoal *= globalParamsSizeAimBonus;

		return SizeGoal;
	}
	//speed
	public int SpeedAim(ArmUnitShip armUnitShipHeroPlayer, int globalParamsSpeedAimBonus)
	{
		int RealSpeed;
		if (armUnitShipHeroPlayer.Speed > armUnitShipHeroPlayer.SpeedSteam)
		{
			RealSpeed = armUnitShipHeroPlayer.Speed;
		}
		else
		{
			RealSpeed = armUnitShipHeroPlayer.SpeedSteam;
		}
		int SpeedGoal = RealSpeed * globalParamsSpeedAimBonus;


		return SpeedGoal;
	}

	public void SaveSalvoQuick(ShipCannon shipCannon, int GlobalParamsTimeQuick)
	{
		//записывает время выстрела
		shipCannon.TimeQuick = GlobalParamsTimeQuick;
		//ShipName[ShipNumber]["Quick" + ShipNumber] = globalParams.TimeQuick;
	}


	public AffectHit TakenHitReckoning(ArmUnitShip armUnitShipHeroFiend, ShipCannon shipCannon,
			 //int BAmount,
			 int Distance)
	{

		//System.out.println("!!!!! TypeCannon=" + shipCannon.TypeCannon + "= SHIP @ id Size  = " + shipCannon.Size);

		//falconet
		if (shipCannon.Size == 0 || shipCannon.Size == 1 || shipCannon.Size == 2)
		{
			//Проверка может ли орудие стрелять
			//определяет куда попадет по борту или экипажу

			//куда попали в борт
			AffectHit affectHit = new AffectHit();

			//System.out.println("timeSalvoAppend attac $$$ =attack player = timeSalvoAppen****" + shipCannon.TypeCannon);
			var rand = new System.Random();

			//int shipCapsuleRandom = (int)Math.floor(Math.random() * armUnitShipHeroFiend.ShipCapsuleList.size());
			int shipCapsuleRandom = rand.Next(armUnitShipHeroFiend.ShipCapsuleList.Count);
			affectHit.CapsuleCount = shipCapsuleRandom;
			ShipCapsule shipCapsule = armUnitShipHeroFiend.ShipCapsuleList[shipCapsuleRandom];

			affectHit.ShipCapsuleRandom = shipCapsuleRandom;
			affectHit.ShipCapsule = shipCapsule;

			affectHit.Nature = Test_Pierce(shipCapsule, shipCannon,
							Distance);


			affectHit.Caliber = shipCannon.Size;

			affectHit.OccurHit = GetHarmCannon(shipCapsule, shipCannon,
					 Distance);


			//affectHit.Address=BAmount;
			//affectHit.HitPlace=Test_Pierce_hit;
			return affectHit;
		}

		return null;
	}
	public DamageFromCannon Test_Pierce(ShipCapsule ShipCapsule, ShipCannon shipCannon,
			int Distance)
	{


		// vertical hit
		return Test_Pierce_Verical(ShipCapsule, shipCannon, Distance);

	}
	public DamageFromCannon Test_Pierce_Verical(ShipCapsule ShipCapsule, ShipCannon shipCannon,
			int Distance)
	{
		if (Pierce_Armor_AndDamage(ShipCapsule, shipCannon,
				 Distance) == true)
		{

			var rand = new System.Random();
			

			DamageFromCannon damFromCannon = Damage_Ship_Usual(shipCannon);
			damFromCannon.Pierce = true;
			damFromCannon.Event = CritHitCard(ShipCapsule);
			if (ShipCapsule.WaterLine)
			{
				//damFromCannon.Flow = (1 == (int)Math.floor(Math.random() * 2));
				damFromCannon.Flow = (1==rand.Next(1));
				//damFromCannon.FlowValue = (int)Math.floor(Math.random() * 2);
				damFromCannon.FlowValue = rand.Next(2);
			}
			//damFromCannon.Shrapnel = (int)Math.floor(Math.random() * shipCannon.Worse);
			damFromCannon.Shrapnel = rand.Next(shipCannon.Worse);
			/*
			OccurHitVolley[OccurHitVolley.length-1].history="no_pierce";
			*/
			return damFromCannon;
		}
		DamageFromCannon damageFromCannon = new DamageFromCannon();
		damageFromCannon.Pierce = false;
		return damageFromCannon;
	}
	public String CritHitCard(ShipCapsule ShipCapsule)
	{

		if (ShipCapsule.WaterLine)
		{

			return "CritHit_Pierce";

		}
		return "CritHitBoard";

	}
	public DamageFromCannon Damage_Ship_Usual(ShipCannon shipCannon)
	{
		DamageFromCannon damageFromCannon = new DamageFromCannon();
		if (shipCannon.Size == 2)
		{
			//DamageBigCannon(HitBoard,Over);
			damageFromCannon.BigCannon = true;
		}
		else
		{
			//CanPresent.push({Place:HitBoard,Over:Over,Grit:false});
		}
		return damageFromCannon;
	}
	public bool Pierce_Armor_AndDamage(ShipCapsule ShipCapsule, ShipCannon shipCannon,
			int Distance)
	{

		if (ShipCapsule.Armor - HarmCannonArmor(shipCannon, Distance)
				< 0 && ShipCapsule.ArmorBoard == false)
		{
			OccurHitList.Add(GetHarmCannon(ShipCapsule, shipCannon,
					 Distance));
			/*
			int InsideBurst=HarmCannon(shipCannon,Distance);
			
			ShipCapsule.Board-= InsideBurst;
			
			OccurHitList.add(new OccurHit(InsideBurst,ShipCapsule.WaterLine));
*/
			return true;
		}

		return false;
	}
	private OccurHit GetHarmCannon(ShipCapsule ShipCapsule, ShipCannon shipCannon,
			int Distance)
	{
		int InsideBurst = HarmCannon(shipCannon, Distance);
		ShipCapsule.Board -= InsideBurst;
		return new OccurHit(InsideBurst, ShipCapsule.WaterLine);
	}


	public static int HarmCannonArmor(ShipCannon shipCannon, int Distance)
	{
		int Detriment = Calculation_Pierce(shipCannon, Distance);

		int DetrimentMin = 0;
		if (Detriment < 0)
		{
			Detriment = 0;

		}

		if (shipCannon.PierceMin == true)
		{
			DetrimentMin = (int)(Detriment * 0.3f);
		}
		var rand = new System.Random();
		int DetrimentRandom = rand.Next(Detriment) + 1 + DetrimentMin;

		//int DetrimentRandom = (int)Math.floor(Math.random() * Detriment) + 1 + DetrimentMin;

		//заодно записать время выстрела
		shipCannon.TimeQuick = MapWorldModel.TimeQuick;

		return DetrimentRandom;

	}
	public static int HarmCannon(ShipCannon shipCannon, int Distance)
	{

		int Detriment = Calculation_Worse(shipCannon, Distance);
		if (Detriment < 0)
		{
			Detriment = 0;

		}
		//int DetrimentRandom = (int)Math.floor(Math.random() * Detriment) + 1;

		var rand = new System.Random();
		int DetrimentRandom = rand.Next(Detriment)+1;
	
		return DetrimentRandom;
	}
	public static int Calculation_Worse(ShipCannon shipCannon, int Distance)
	{

		int Velocity_Shell = 2000 - shipCannon.Velocity;
		int Bracket = Distance - shipCannon.Range - 1;
		int Detriment = Velocity_Shell / Bracket + shipCannon.Worse;
		return Detriment;
	}
	public static int Calculation_Pierce(ShipCannon shipCannon, int Distance)
	{
		int Velocity_Shell = 2000 - shipCannon.Velocity;

		int Bracket = Distance - shipCannon.Range - 1;
		int Detriment = Velocity_Shell / Bracket + shipCannon.Pierce;
		return Detriment;

	}
}
