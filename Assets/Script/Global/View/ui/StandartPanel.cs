using UnityEngine;
using System.Collections;
using RTS;
using UnityEngine.UI;

public class StandartPanel : MonoBehaviour {

    

    void Start () {
		
		EventListeren.eventDispatchEvent(CommandState.BlockScroll.ToString(),"");
	}

	public void clickT() {
		EventListeren.eventDispatchEvent(CommandState.unBlockScroll.ToString(),"");
       // Destroy(transform.gameObject);
        //Destroy(transform.parent.gameObject);
       // Destroy(transform.parent.parent.parent.gameObject);
        Destroy(transform.parent.parent.gameObject);
        
    }
}
