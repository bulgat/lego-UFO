using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using System.Linq;
using Assets.Global;
using SimpleJSON;

public class ModelTacticFight : MonoBehaviour {

	public static string tacticLog = "";

	// Use this for initialization
	void Start () {
		EventListeren.eventListerenEvent += on_start_battle;
        EventListeren.eventListerenEvent += StickPlayerAttackBase;
        EventListeren.eventListerenEvent += StickPlayerDefenceBase;
    }
    
    void Update()
    {

        // удаление с тактического поля кораблей уплывших за границы карты.
        clearAllShipMoveOutTacticMap();
        AIStickBattleFiend();

        if (GlobalConf.ModeStickBattle) {
            AIStickBattleFiend();
            
        }
    }
    private void AIStickBattleFiend()
    {
        if (GlobalConf.Money[1]>10) {
            List<int> orderUnit = new List<int>() {0,1,1,2};
            foreach (int typeUnitId in orderUnit)
            {
                var typeUnitOne = GlobalConf.UnitConfig_ar.Where(a => a.Id == typeUnitId).FirstOrDefault();
                GlobalConf.Money[1] -= typeUnitOne.Cost;
            var I = new JSONClass();
            I[CommandSend.typeUnit.ToString()] = typeUnitId.ToString();
            EventListeren.eventDispatchEvent(CommandState.BuyUnitStickBattleFiend.ToString(), I.ToString());

            }
            
        }

            
    }

    // Событие Сражение между игроками
    private void on_start_battle(string isPower, string obj) {
		if (isPower == CommandState.AttackShip.ToString ()) {
			tacticLog = "";
		}
	}
    /// <summary>
    /// Игроку атаковать базу противника.
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="obj"></param>
    private void StickPlayerAttackBase(string isPower, string obj)
    {
        if (isPower == CommandState.StickPlayerAttackBase.ToString())
        {
            
           var unitBasa = GetBasa(true);

            List<Unit> unitPlayer_ar = GetAllUnitPlayer();
            foreach (var unit in unitPlayer_ar)
            {
                //unit.destination = new Vector3(-54,6,1);
                unit.destination = unitBasa.transform.position;
                unit.moveToDest = unitBasa.transform.position;
                unit.stateUnit.rotate = true;
                // unit.attacking = true;
            }

                
        }
    }

    private void StickPlayerDefenceBase(string isPower, string obj)
    {
        if (isPower == CommandState.StickPlayerDefenceBase.ToString()) {
            var unitBasa = GetBasa(false);

            List<Unit> unitPlayer_ar = GetAllUnitPlayer();
            foreach (var unit in unitPlayer_ar)
            {

                unit.stateUnit.rotate = true;
                unit.moveToDest = unitBasa.transform.position;

            }
print("000 ВРАГ .     eccMap "+ unitPlayer_ar.Count());
        }
    }
    /// <summary>
    /// Дать все тактические подвижные юниты игрока.
    /// </summary>
    /// <returns></returns>
    private List<Unit> GetAllUnitPlayer() {
       
        var shipUnit_ar = GetUnitShipScript();
        List<Unit> unitPlayer_ar = shipUnit_ar.Where(a => a.objectName != NameUnit.building.ToString()).Where(a => a.fiend == false).ToList();
        return unitPlayer_ar;
    }
    /// <summary>
    /// Дать базу. Вражескую.
    /// </summary>
    /// <param name="fiend"></param>
    /// <returns></returns>
    private Unit GetBasa(bool fiend)
    {
        var shipUnit_ar = GetUnitShipScript();
        Unit unit = shipUnit_ar.Where(a => a.objectName == NameUnit.building.ToString()).Where(a => a.fiend == fiend).FirstOrDefault();
        return unit;
    }
    private List<Unit> GetUnitShipScript() {
        var ship_ar = GameObject.FindGameObjectsWithTag("ship");
        var shipUnit_ar = new List<Unit>();
        foreach (GameObject ship in ship_ar)
        {
            if (ship != null)
            {
                Unit unitShip = ship.GetComponent<Unit>();
                shipUnit_ar.Add(unitShip);
            }

        }
        return shipUnit_ar;
    }


        
    /// <summary>
    /// удаление с тактического поля кораблей уплывших за границы карты.
    /// </summary>
    private void clearAllShipMoveOutTacticMap() {
		var ship_ar =  UserInput.getAllShip("ship");

        GameObject ground=null;
        foreach (string searchStr in ResourceManager.Ground) {
            ground = GameObject.Find(searchStr);
            if (ground!=null) {
                break;
            }
        }
        int distanceDeleteMap = GlobalConf.distanceDeleteMap;
        if (GlobalConf.ModeStickBattle) {
            distanceDeleteMap = StickBattle.DistanceDeleteMapOut;
        }
        //GameObject ground = GameObject.Find("Ground(Clone)");

        if (ground != null) {

			foreach (var ship in ship_ar) {
                // Удаляем по расстоянию от центра.
				if (distanceDeleteMap < Vector3.Distance (ground.transform.position, ship.transform.position)) {
                    // удалить с тактической карты.
                    DeleteShipTactic(ship);
              
					break;

				}
                // Удаляем по расстоянию падения с краю карты.
                if (ship.transform.position.y<2) {
                    DeleteShipTactic(ship);
                    break;
                }

			}
			//Debug.Log (ground.transform.position.x + "==" + ground.transform.position.z + " AI " + transform.position.x + "=" + transform.position.z + "  Name =     ##### === L = " + ship_ar.Length + "  *** ");
		}
	}
    /// <summary>
    /// удалить с тактической карты.
    /// </summary>
    /// <param name="ship"></param>
    private void DeleteShipTactic(GameObject ship) {
        Unit unitShip = ship.GetComponent<Unit>();
        tacticLog += "\n корабль " + unitShip.objectName + " покинул поле боя";
        NewUnit unit_Ship = getShipId(unitShip.id);
        deleteSelectShip(unitShip.idFleet, unit_Ship);
        getEscapeShipOtherHero(unit_Ship, unitShip.idFleet);


        Destroy(ship);
    }


	// У всех надо убрать выделение.
	public static void clearSelectAllShip(GameObject[] ship_ar) {
		
		foreach (var ship in ship_ar) {
			var worldShip = ship.GetComponent<WorldObjectUnit>();
			worldShip.SetSelectUnit( false);
			//worldShip.currentlySelected = false;
		}
	}


	// Удалить корабль не только с карты тактики, но и с стратегической карты
	public static void deleteSelectShip(int idFleet, NewUnit unitShip) {
		
			
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if (fleet.id==idFleet) {
				fleet.ship_ar.Remove(unitShip);
			}
		}
			


	}
	public static void deleteSelectIdShip(int idFleet, int idShip) {
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if (fleet.id == idFleet) {
                if (getShipId(idShip)!=null) {
                    fleet.ship_ar.Remove(getShipId(idShip));
                }

				
			}
		}
	}


	private static NewUnit getShipId(int idShip) {
		
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			foreach (NewUnit oneShip in fleet.ship_ar) {
				if (oneShip.uid==idShip) {
					return oneShip;

				}
			}
		}
		return null;
	}

	// Раздать спасенные корабли другим героям.
	private static void getEscapeShipOtherHero(NewUnit unitShip,int idFleet) {



		List<InfoFleet> otherFleet = new List<InfoFleet> ();
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			if (fleet.player) {
				if (fleet.id != idFleet) {
					otherFleet.Add (fleet);
				}
			}
		}
		//print (idFleet +" ###########"+otherFleet.Count+"######## 0 shipTEST = ");
		if (otherFleet.Count>0) {
			int randomFleet = (int)Random.Range(0, otherFleet.Count);

			//Debug.Log("========= "+idFleet+" clear ALL XXXXX"+otherFleet+"XXXX           name = "+unitShip.objectName);
			otherFleet [randomFleet].ship_ar.Add (unitShip);

		}

	}
}
