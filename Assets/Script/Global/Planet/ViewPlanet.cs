using UnityEngine;
using System.Collections;
using RTS;
using SimpleJSON;
using UnityEngine.Video;

public class ViewPlanet : MonoBehaviour {

	public static bool viewPlanetClick=false;
	public GUISkin planetSkin;
	public Texture2D factoryImage;
	public Texture2D chooterImage;
	public Texture2D fiendImage;
	public Texture2D playerImage;

	//public static string namePlanet="";
	public static Vector2 coordinate;

    public Texture2D _BuyUnitImage;
    public Texture2D proof;
	public Material pr;
	public VideoPlayer movTexture;
	public Texture2D transportSkin;
	public static bool descent;
	public static bool _fiend=false;
	private static InfoPlanet myPlanet;

	public static void initPlanet(int id) {


		foreach (InfoPlanet planet in GlobalConf.GetTownList()) {
			if (planet.id == id) {

				//InfoPlanet myPlanet = planet;

				break;
			}
			
		}
	}

	void OnGUI() {
		if (viewPlanetClick) {

		
			//DrawPlanet ();
			DrawFactory(ModPlanet._planetGoto);
			DrawChooter(ModPlanet._planetGoto);

			// Выход с планеты.
			if (GUI.Button (new Rect (Screen.width - 90, Screen.height - 30, 80, 40), "Close")) {


				closePlanet();
			}

		}
	}

	private void closePlanet() {
		viewPlanetClick = false;
		EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(),"");
	}
    /*
	public void DrawPlanet() {



		GUI.skin = planetSkin;
		GUI.BeginGroup(new Rect(0,0,Screen.width,Screen.height));
		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
		GUI.Label(new Rect(200,10,100,100), ModPlanet._planetGoto.nameRegion);
		GUI.Label(new Rect(10,10,ResourceManager.ORDERS_BAR_WIDTH,30), "money = "+ModelGlobal.money);

		if (GUI.Button (new Rect (Screen.width - ResourceManager.ORDERS_BAR_WIDTH - 340, Screen.height - 170, ResourceManager.ORDERS_BAR_WIDTH + 20, 70),  _BuyUnitImage)) {
            closePlanet();
            int costUnit = 1;
            if (ModelGlobal.money - costUnit >= 0) {
				ModelGlobal.money -= costUnit;

				//closePlanet ();
				var I = new JSONClass ();
				I ["x"] = coordinate.x.ToString ();
				I ["y"] = coordinate.y.ToString ();
				EventListeren.eventDispatchEvent (CommandState.BuyShip.ToString (), I.ToString ());
				//Message.message ("Куплен транспорт. Money = " + ModelGlobal.money+" Cost = "+ costUnit);


                var textI = new JSONClass();
                textI[CommandState.Message.ToString()] = "Куплен транспорт. Money = " + ModelGlobal.money + " Cost = " + costUnit;
                textI["image"] = "money";
                EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
            } else {
				//Message.message ("Недостаточно денег. Money = "+ ModelGlobal.money + " Cost = " + costUnit);
                var textI = new JSONClass();
                textI[CommandState.Message.ToString()] = "Недостаточно денег. Money = " + ModelGlobal.money + " Cost = " + costUnit;
                textI["image"] = "noMoney";
                EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());

            }
		}
		if (descent) {
			GUI.DrawTexture (new Rect (150, 150, 330,  210),movTexture);
			DrawDescentBattle();

			movTexture.Play();
			if (!ModPlanet._planetLanding.player) {
				GUI.DrawTexture (new Rect (10, 10, 330,  70),fiendImage);
			} else {
				GUI.DrawTexture (new Rect (10, 10, 330,  70),playerImage);
			}
		}

		GUI.EndGroup();
		
	}
    */
	public float Speed = 50;
	private float stepImpact=300;
	public void DrawDescentBattle() {
		// продолжать битву?
		int result=ModPlanet.StopDescentBattle();
		result = 1;
		if (result>0){
			print ("WWWWWWWWW   ___________"+result);
			viewPlanetClick=false;
			if (result==1) {
				
				//Message.message("Город захвачен.");
                var textI = new JSONClass();
                textI[CommandState.Message.ToString()] = "Город захвачен.";
                EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
            } else {
				//Message.message("Планете удалось отбить десант.");
                var textI = new JSONClass();
                textI[CommandState.Message.ToString()] = "Планете удалось отбить десант.";
                EventListeren.eventDispatchEvent(CommandState.Message.ToString(), textI.ToString());
            }
			closePlanet();
			descent = false;

			return;
		}
		
		Vector2 chooterDescent= ModPlanet.DrawDescentBattle ();
		int left = (int)chooterDescent.x;
		int right=(int)chooterDescent.y;

		Debug.Log(result +"======  left = "+left+"__right = "+right);

		GUI.DrawTexture (new Rect (150, 50, 430,  110),transportSkin);
		if (left==0) {
			left = 1;
		}
		int interval_left = 150 / left;
		int interval_right = 150 / right;

		for (int i=0; i<left; i++) {
			GUI.DrawTexture (new Rect (150+i*interval_left, 50+20, 50,  50),chooterImage);
		}
		for (int i=0; i<right; i++) {
			GUI.DrawTexture (new Rect (150+430-50-i*interval_right, 50+20, 50,  50),chooterImage);
		}

		var moveAmount = Speed * Time.deltaTime;
		stepImpact -= moveAmount;
		if (stepImpact <0) {
	
			stepImpact=300;
			EventListeren.eventDispatchEvent(CommandState.PlanetChooter.ToString(),"");
		}
	}
	public void DrawFactory(InfoPlanet planetInner) {

		for (int i=0; i<planetInner.factory; i++) {
			GUI.DrawTexture (new Rect (0+i*200, 300, 200,  150),factoryImage);
		}

	}
	public void DrawChooter(InfoPlanet planetInner) {
		for (int i=0; i<planetInner.chooter; i++) {
			GUI.DrawTexture (new Rect (0+i*50, 400, 50,  50),chooterImage);
		}
	}
}
