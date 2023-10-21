using System.Collections;
using System.Collections.Generic;

using System.Linq;
public class FieldArmyView : FieldArmyBasic
{
    public List<UnitTactic> _battleTactic_ar;
    public UnitResultTactic _unitResultTactic;

    //List<Sprite> TextureUnit_ar;
    string nameImage;
    //GameObject ImageObject;
    float _countFrameFieldViev;
    int _indexDead;
    bool _playerAttack = false;

    public FieldArmyView()
    {

    }

    public void FieldArmyViewSet(TacticPlanetView tacticPlanetView, float widthStage, float HeightStage, float countFrame)
    {





       // int SelectShipFiend = Tactic.GetTactic().SelectShipPlayer;
       // int SelectShipPlayer = Tactic.GetTactic().SelectShipFiend;



        ShipUnit shipPlayerList = Tactic.GetTactic().GetPlayerFleet().GetShipName();
        ShipUnit shipFiendList = Tactic.GetTactic().GetFiendFleet().GetShipName();

        ShipUnit shipPlayer = shipPlayerList;
        ShipUnit shipFiend = shipFiendList;

        _battleTactic_ar = new List<UnitTactic>();

        _unitResultTactic = Tactic.GetTactic().GetResultTacticBattle()[0];

        float proportion = (float)widthStage / 1400;
        GridCrewScience scienceUnit;

        SetUnitToField(widthStage, HeightStage,
                shipPlayer, true, BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience(), tacticPlanetView);

        SetUnitToField(widthStage, HeightStage,
                shipFiend, false, BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience(), tacticPlanetView);

        foreach (ArmUnit unit in shipFiend.GetArmUnitArray())
        {
            scienceUnit = BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience()[unit.GetUnit()];


        }
        _countFrameFieldViev = countFrame;
    }
   
    private void SetUnitToField(float widthStage, float HeightStage,
            ShipUnit shipPlayer, bool PlayerLeft, List<GridCrewScience> BasaPurchaseUnitScience_ar,
            TacticPlanetView tacticPlanetView)
    {
        float proportion = (float)widthStage / 1400;
        GridCrewScience scienceUnit;
        for (int i = shipPlayer.GetArmUnitArray().Count - 1; i >= 0; i--)
        {
            ArmUnit armUnit = shipPlayer.GetArmUnitArray()[i];
            int numUnitImage = armUnit.GetUnit();
            int idUnit = armUnit.Id;
            scienceUnit = BattlePlanetModel.GetBattlePlanetModelSingleton().GetBasaPurchaseUnitScience()[numUnitImage];


            // load texture unit
  
            ///tacticPlanetView.SetGameObject(numUnitImage * 3, idUnit);

            //UnitShipTexture unitShipTexture = new UnitShipTexture();
            UnitTypeShipView unitTypeShipView;/// = unitShipTexture.GetShipSea(numUnitImage, BasaPurchaseUnitScience_ar);
           // Image imageShip = null;
     
            UnitTactic unitTactic = new UnitTactic(PlayerLeft, i, widthStage,
                (float)scienceUnit.MinSpeed * proportion,
                    (float)scienceUnit.Speed * proportion,
                    GetProportionScene(scienceUnit,
                widthStage, proportion, 0));

            unitTactic.SetUnitTactic(i, widthStage, HeightStage,

                GetProportionScene(scienceUnit, widthStage, proportion, 0),
                PlayerLeft, 
                shipPlayer.GetArmUnitArray()[i].Id,
                scienceUnit.TacticStopFire,
                1, tacticPlanetView);
            _battleTactic_ar.Add(unitTactic);
            
        }
    }
    public UnitResultTactic DrawFieldUnit(
                                 int DamageAnimCoef,
            List<UnitTactic> BattleTactic_ar,
            List<UnitResultTactic> unitResultTactic_ar,
            float CountFrame,
            TacticPlanetView tacticPlanetView
            )
    {
 

        int countFrame = 0;
        foreach (UnitTactic unitT in BattleTactic_ar)
        {
            
            unitT.DrawUnit(tacticPlanetView, CountFrame, unitT._Existense);

            if (CountFrame >= _countFrameFieldViev + .2)
            {


                if (_indexDead < unitResultTactic_ar.Count)
                {


                    UnitResultTactic unitResultTactic = unitResultTactic_ar[_indexDead];

                    _unitResultTactic = unitResultTactic;

                   

                    // get dead unit 
                    var unitIdDead = BattleTactic_ar.Where(a => a.GetId() == unitResultTactic.UnitIdDead).FirstOrDefault();
                    if (unitResultTactic.BlockDead==false)
                    {
                        if (unitIdDead == null)
                        { 
                       
                        }
                            // dead unit
                            unitIdDead.SetDead(unitResultTactic.Existense);
                       // }
                       // else 
                       // {
                        //   
                        //}
                    }
                    _playerAttack = unitResultTactic.AttackPlayer;
                    // unit fire
                    var unitIdWin = BattleTactic_ar.Where(a => a.GetId() == unitResultTactic.UnitIdWin).FirstOrDefault();
                    unitIdWin.SetFire(CountFrame);

                    
                    // unit fire
                   
                }
                else
                {

                    // end exit Tactic

                    Tactic.GetTactic().ReleaseDead();
                    break;

                }
                
                _countFrameFieldViev = CountFrame;
                _indexDead += 1;

            }
            countFrame++;
        }

        return _unitResultTactic;
    }
}
