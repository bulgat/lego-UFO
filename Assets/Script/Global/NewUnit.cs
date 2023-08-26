using UnityEngine;
using System.Collections;
using RTS;

public class NewUnit {
	public string objectName;

	public bool fiend;
	public int hitPoints;
    public int weaponRange = 10;
    public int weaponDamage = 1;
    public int weaponRecharge = 1;
    public int fast = 0;

    public int uid;
	public string typeShip = "";
	public int typeShipId = 0;

    public bool placeUnitMap = false;
    public int placeUnitX = 0;
    public int placeUnitY = 0;

    public int type_Ship {
		set { 
			if (value == 0) {
				typeShip =ShipState.Battle.ToString();
			}
			if (value == 1) {
				typeShip =ShipState.Transport.ToString();
			}
			typeShipId = value;
		}

	}


}
public class UnitSpecification {
    public int Id { set; get; }
    public string Name { set; get; }
    public int HitPoint { set; get; }
    public int WeaponRange { set; get; }
    public int WeaponDamage { set; get; }
    public int WeaponRecharge { set; get; }
    public int Fast { set; get; }
    public int Cost { set; get; }
}
public class CameraBlock {
    public Vector2 Position_x { set; get; }
    public Vector2 Position_z { set; get; }
}
