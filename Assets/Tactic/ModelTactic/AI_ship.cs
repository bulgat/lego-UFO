using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_ship : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static int? getShip(Vector3 shipCoordinat,GameObject[] ship_ar,bool fiend, bool noDifference=false) {

		List<InfoAiShip> InfoAiShip_ar = new List<InfoAiShip> ();
		int i=0;

		// Выбор самого последнего существующего вражеского корабля.
		foreach(var ship in ship_ar) {
			var unitShip = ship.GetComponent<Unit>();

			if (unitShip!=null) {
				// атакуем игрока или противника.
				if (unitShip.fiend!=fiend) {
                    // Массив противников.
					InfoAiShip_ar.Add (new InfoAiShip () { id = i, spacing = Vector3.Distance(shipCoordinat,ship.transform.position) });
				}
                if (noDifference==true) {
                    // Массив противников.
                    InfoAiShip_ar.Add(new InfoAiShip() { id = i, spacing = Vector3.Distance(shipCoordinat, ship.transform.position) });
                }
			}

			i++;
		}
        // Если врагов нет возвращаем 0
        //if (!fiend)
        //{
            if (InfoAiShip_ar.Count == 0)
            {
                return null;
            }
        //}
		//return num;

		// Выбор ближайшей цели.
		float maxDist = 1000;
		int idMinDist = 0;
		foreach (var InfoAiShip in InfoAiShip_ar) {
			//Debug.Log("№№№№№ _____ Player  @@  "+InfoAiShip.spacing);
			if (InfoAiShip.spacing<maxDist) {
				maxDist = InfoAiShip.spacing;
				idMinDist = InfoAiShip.id;
			}
		}
		//Debug.Log(maxDist+" _____ Player  @@  "+idMinDist);
		return idMinDist;
	}
}

// Класс для хранение информации АИ.
public class InfoAiShip {
	public int id = 0;
	public float spacing=0;
}