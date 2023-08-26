using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using RTS;

public class UIBattleTactic : MonoBehaviour {

	public Image BattleInterfaceImageHero;
	public Text BattleInterfaceNameHero;

	public Text TacticScrLog;

    public Text BattleInterfaceHitPoints;
    public Text BattleInterfaceSelectionName;

    public Image ImageSelectUnit;
    public Sprite[] ImageHero;
    void Start () {
	
	}
	public void SetInfo (int IndexImage,string Text) {
        this.BattleInterfaceNameHero.text = Text;
        this.BattleInterfaceImageHero.sprite = this.ImageHero[IndexImage];
    }


	// Update is called once per frame
	void Update () {
        BattleInterfaceHitPoints.text = UserInput.hitPoints;
        BattleInterfaceSelectionName.text = UserInput.selectionName;
        if (UserInput.selectionImage != "")
        {
            ImageSelectUnit.sprite = UserInput.HUD_UserInput.imageTypeUnit_ar.Where(a => a.name == UserInput.selectionImage).First();

        }
    }
}
