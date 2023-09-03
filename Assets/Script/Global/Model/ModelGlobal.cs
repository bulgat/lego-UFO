using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using SimpleJSON;
using System.Linq;

public class ModelGlobal : MonoBehaviour
{

    public static ModelGlobal model;

    private int id_attackFleet = 0;
    private ModPlanet _ModPlanet;
    private static InfoFleet _attackFleetPlanet;
    private static InfoPlanet _attackDefencePlanet;
    public static Vector2 _clickFleetChangeHero = Vector2.zero;

    public static List<NewUnit> _LeftChangeShip;
    public static List<NewUnit> _RightChangeShip;

    // Use this for initialization
    void Start()
    {
        model = this;
        EventListeren.eventListerenController += onTurn;
       // EventListeren.eventListerenController += ChangeHeroShip.searchPlayer;
        //EventListeren.eventListerenController += ChangeHeroShip.LeftChangeShipFleet;
       // EventListeren.eventListerenController += ChangeHeroShip.RightChangeShipFleet;
     //   EventListeren.eventListerenController += buyShip;

        ModPlanet _ModPlanet = new ModPlanet();

      //  EventListeren.eventListerenController += _ModPlanet.bombPlanet;



        EventListeren.eventListerenController += _ModPlanet.planetChooterBattle;
      //  EventListeren.eventListerenController += _ModPlanet.PlanetLanding;
        EventListeren.eventListerenController += _ModPlanet.GotoPlanet;


    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Кнопка сделать стратегический ход.
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="no"></param>
	public void onTurn(string isPower, string no)
    {

        //if (isPower == CommandState.Turn.ToString())
       // {

            //GlobalConf.TurnButtonClick();
       // ControllerButton.EventCall(ControllerConstant.Turn, ControllerConstant.Turn, null);

        // Глобальная победа.
        if (!GlobalVictory.StrategVictoryPlayer(true))
            {
                //Message.message("Враг выиграл.");
                var textI = new JSONClass();
                textI[CommandState.MessageGlobalWin.ToString()] = false.ToString();
                EventListeren.eventDispatchEvent(CommandState.MessageGlobalWin.ToString(), textI.ToString());


                Player.restartGame();
            }
            // Глобальная победа.
            if (!GlobalVictory.StrategVictoryPlayer(false))
            {

                var textI = new JSONClass();
                textI[CommandState.MessageGlobalWin.ToString()] = true.ToString();
                EventListeren.eventDispatchEvent(CommandState.MessageGlobalWin.ToString(), textI.ToString());
                Player.restartGame();
            }

       // }
    }



    /*
    public static void ResetAttackPlanet()
    {
        _attackFleetPlanet = null;
        _attackDefencePlanet = null;
    }
    */

  
    public static InfoFleet getFleetId(int id)
    {

        

        foreach (InfoFleet fleet in GlobalConf.GetViewFleetList())
        {

            if (fleet.id == id)
            {
                return fleet;
            }
        }
       

        return GlobalConf.GetViewFleetList().First();
    }
    public static int getFleetTransport(InfoFleet fleet)
    {
        int transport = 0;
        foreach (NewUnit ship in fleet.ship_ar)
        {
            if (ship.typeShip == ShipState.Transport.ToString())
            {
                transport++;
            }
        }
        return transport;
    }
    /*
    public static bool destroyFirstFleetTransport(InfoFleet fleet)
    {
        foreach (NewUnit ship in fleet.ship_ar)
        {
            if (ship.typeShip == ShipState.Transport.ToString())
            {
                fleet.ship_ar.Remove(ship);
                return true;
            }
        }
        return false;
    }
    */
    public static InfoFleet getAttackFleetPlanet()
    {
        return _attackFleetPlanet;
    }
    public static InfoPlanet getAttackDefencePlanet()
    {
        return _attackDefencePlanet;
    }

    public static void destroyFleet(int fleet_battle_id)
    {

        foreach (InfoFleet fleet in GlobalConf.GetViewFleetList())
        {
            if (fleet.id == fleet_battle_id)
            {
                GlobalConf.GetViewFleetList().Remove(fleet);
                break;
            }
        }

        //activeCursorState

    }
    /// <summary>
    /// Купить корабль.
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="obj"></param>
	public static void buyShip(string isPower, string obj)
    {
        if (isPower == CommandState.BuyShip.ToString())
        {
            var ar = JSONNode.Parse(obj);

            int typeUnit = int.Parse(ar["type"]);
            // Но надо поискать ближайший флот, что-бы туда влиться.

            InfoFleet Fleet = getFleetWithCoordinate(int.Parse(ar["x"]), int.Parse(ar["y"]));

            if (Fleet != null)
            {


                // Определяем принадлежность флота и даем знать юниту, кому он принадлежит.
                Fleet.ship_ar.Add(GlobalConf.AddShipBasa(typeUnit, Fleet.player == false));
                return;
            }



            // Добавить новый флот.

            GlobalConf.GetViewFleetList().Add(new InfoFleet("player", new Vector2(int.Parse(ar["x"]), int.Parse(ar["y"])), true, GlobalConf.IncrementFleet++, new List<NewUnit>() {
                   GlobalConf.AddShipBasa(typeUnit, false)
            }, "Ninja buy", 4, 0, 0));



        }
    }
    /// <summary>
    /// Дать флоот только по ее координатам.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static InfoFleet getFleetWithCoordinate(int x, int y)
    {
        foreach (var InfoFleet in GlobalConf.GetViewFleetList())
        {
            if (InfoFleet.coordinate == new Vector2(x, y))
            {
                return InfoFleet;
            }
        }
        return null;
    }
    /*
    public static bool fleetAbovePlanet(int x, int y, bool player)
    {

        foreach (InfoPlanet planet in GlobalConf.GetTownList())
        {
            if (planet.coordinate.x == x && planet.coordinate.y == y)
            {
                if (planet.player == player)
                {
                    return false;
                }

                return true;
            }
        }
        return false;
    }
    */
    public static InfoPlanet getFleedAbovePlanet(int x, int y)
    {
        foreach (InfoPlanet planet in GlobalConf.GetTownList())
        {
            if (planet.coordinate.x == x && planet.coordinate.y == y)
            {
                return planet;
            }
        }
        return null;
    }
    public static InfoPlanet PlanetSelectCoordinate(int x, int y)
    {
        foreach (InfoPlanet planet in GlobalConf.GetTownList())
        {
            if (planet.coordinate.x == x && planet.coordinate.y == y)
            {
                return planet;

            }
        }
        return null;
    }

}
