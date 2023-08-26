using UnityEngine;
using System.Collections;

public class EventListeren : MonoBehaviour {
	
	public delegate void Pow (bool isP);
	public static event Pow eventListeren;
	
	public static void eventDispatch(bool isPower) {
		
		eventListeren(true);
	}

	public static void eventDispatchTurn(string isPower) {
		
		eventListerenTurn(isPower);
	}

	public delegate void PowTurn (string isP);
	public static event PowTurn eventListerenTurn;

	//

	public static void eventDispatchEvent(string isPower,string obj) {

		eventListerenEvent(isPower,obj);
	}

	public delegate void DispatchEvent (string isP,string obj);
	public static event DispatchEvent eventListerenEvent;

	public static void eventDispatchController(string isPower,string obj) {
		
		eventListerenController(isPower,obj);
	}
	
	public delegate void DispatchController (string isP,string obj);
	public static event DispatchEvent eventListerenController;
}