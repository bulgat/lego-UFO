using System.Collections;
using System.Collections.Generic;

using System;

public class SeaAnimationMove 
{
    /*
    public long _tickReal;
    public int _continuance = 50;
    public void InitArrange(SetFieldArmyView setFieldArmyView, SeaTactic seaTactic)
    {
        //Point widthHeigt = GetWidthHeight(StageWidthX, (int)(StageHeightY - GlobalParamView.widthPanelBattlePlanet), 6);
        //float widthTile = widthHeigt.X;
        //float heightTile = widthHeigt.Y;

        //List<ArmUnit> AllArmyUnitTactic = setFieldArmyView.GetAllArmyUnitTactic();

        //foreach (GridFleet gridFleet in seaTactic.GetPrototypeHeroDemo().GetHeroFleet())
        //{
     
        //}

    }
    public CommandStrategy AnimationCommand(CommandStrategy commandStrategy, long Tick,
            SetFieldArmyView setFieldArmyView, int StageWidthX, int StageHeightY, int CountTurn, SeaTactic seaTactic,
            List<GameObject> SceneList, List<GameObject> UnitHeroGameObjectList, 
            GameObject ExplodePrefabs,Action<int> SetExplodeFleet)
    {

        

        if (SeaTactic.GetTactic().GetCommandStrategyList().Count > 0)
        {
            if (commandStrategy == null)
            {
                // animation capture island

                commandStrategy = SeaTactic.GetTactic().GetCommandStrategyList()[0];

                _tickReal = Tick;

                ControllerButton.SetBlock();
            }
        }


        if (_tickReal + _continuance > Tick)
        {
            if (_tickReal + 1 > Tick)
            {
            }
            else
            {
                if (commandStrategy != null)
                {
                    if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
                    {
                       // MoveFleet(setFieldArmyView, commandStrategy, StageWidthX, StageHeightY);


                        ///////
         
                        
                        
                        
                    GameObject heroFleet = GetUnitGameObject(UnitHeroGameObjectList, commandStrategy.GridFleet.GetId());
                       
                        
                    float heroZ = heroFleet.transform.position.z;

                        GameObject tileOld = GetTileGameObject(SceneList, (int)commandStrategy.GridFleetOldPoint.X, (int)commandStrategy.GridFleetOldPoint.Y);
                        GameObject tileNew = GetTileGameObject(SceneList, (int)commandStrategy.GridFleetNewPoint.X, (int)commandStrategy.GridFleetNewPoint.Y);

                        heroFleet.transform.position = Vector3.MoveTowards(
                                new Vector3(heroFleet.transform.position.x, heroFleet.transform.position.y, heroZ),
                                new Vector3(tileNew.transform.position.x, tileNew.transform.position.y, heroZ),
                                GetStep());

                        ///////
                    }

                    if (commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
                    {

                 

    

                        // result attack
                        ExecuteCommandTactic executeCommandTactic = new ExecuteCommandTactic();

                        commandStrategy.unitResultTactic_ar =
                                executeCommandTactic.GetUnitResultTactic(commandStrategy, CountTurn, 0);

                        
                        Debug.Log(commandStrategy.GridFleet.GetId()+"   #  _ size= " + commandStrategy.unitResultTactic_ar);

                        // ExplodePrefabs
Debug.Log(_continuance + "   @@@@@@@@@@@@@@@@@@@@@@@@     heroFleet = " + commandStrategy.GridFleetVictim);
                        SetExplodeFleet(commandStrategy.GridFleetVictim.GetId());

                            
                        ///////
                        ///

                        //InitArrange(StageWidthX, StageHeightY, setFieldArmyView);
                        // view damage animation.
                        DrawUnitDamageAndDead(setFieldArmyView,
                                commandStrategy.unitResultTactic_ar[0].UnitIdDead,
                                commandStrategy.unitResultTactic_ar[0].UnitIdWin,
                                false,
                                commandStrategy.unitResultTactic_ar[0].Existense,
                                commandStrategy.unitResultTactic_ar[0].Salvo,
                                commandStrategy.unitResultTactic_ar[0].ImprintVolleyList, seaTactic
                                );

                  
                    }

                }
            }
        }
    
    
        if (_tickReal + _continuance <= Tick)
        {
            if (commandStrategy != null)
            {
                if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
                {

                    if (commandStrategy.GridFleet != null)
                    {
           
                        //if (groupActor != null)
                        //{

                        //float stepTick = GetStepTick(Tick);
                        Point indicium = GetPointMoveFleet(commandStrategy);

                        Point oldMove = new Point(commandStrategy.GridFleetOldPoint.X,
                                commandStrategy.GridFleetOldPoint.Y);

               
                        //}

                    }
                }
                if (commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
                {
                
                    //unitTacticVictim.DrawUnitCount();

                }
            }
        }
        //}

        
        // END
        if (_tickReal + _continuance <= Tick)
        {
            

            // end
            if (commandStrategy != null)
            {
                if (commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
                {

                    DrawUnitDamageAndDead(setFieldArmyView,
                        commandStrategy.unitResultTactic_ar[0].UnitIdDead,
                        commandStrategy.unitResultTactic_ar[0].UnitIdWin,
                        true, 0,
                        commandStrategy.unitResultTactic_ar[0].Salvo,
                        commandStrategy.unitResultTactic_ar[0].ImprintVolleyList, seaTactic
                            );

                }
                //System.out.println(" attack fleet = " + commandStrategy.GridFleet.GetAttackDone() + "__ REMove command %%%%%  = " + commandStrategy.Id);
                //if (commandStrategy.GridFleetVictim != null)
                //{
                    //System.out.println("0 ======== ===========   Victim =" + commandStrategy.GridFleetVictim.GetAttackDone());
               // }
                commandStrategy.GridFleet.PowerReserveChange(-1);

                setFieldArmyView.PerformCommandSea(commandStrategy, StageWidthX, StageHeightY, SeaTactic.GetTactic());

                //InitArrange(StageWidthX, StageHeightY, setFieldArmyView);

                //SeaTactic._seaChangeStateView = true;


                ControllerButton.UnlockBlock();

                commandStrategy = null;

            }

            //_firstTick = false;
        }

        if (_tickReal + _continuance < Tick)
        {
            ControllerButton.UnlockBlock();
            //_firstTick = false;
        }

        return commandStrategy;
    }
    
    private void DrawUnitDamageAndDead(SetFieldArmyView setFieldArmyView,
            int UnitIdDead, int UnitIdWin, bool Remove, int Existense,
            bool Salvo, List<ImprintVolley> ImprintVolleyList, SeaTactic seaTactic)
    {

        UnitTacticBasic unitTactic = setFieldArmyView.GetUnitTactic(
                setFieldArmyView._unitTacticBasic_ar,
                UnitIdDead);


        if (unitTactic != null)
        {
            if (Remove)
            {
                if (unitTactic._armUnitShip.ShipStatusDead())
                {



                    //setFieldArmyView.RemoveDeadUnitAndGroup(groupActor);

                    setFieldArmyView._unitTacticBasic_ar.Remove(unitTactic);

                    GridFleet gridFleet = seaTactic._prototypeHeroSea.GetFleetWithId(unitTactic.GetId());
                    //System.out.println("DrawUnitDamageAndDead    REMOVE _@@ ");
                    seaTactic._prototypeHeroSea.HeroFleetRemove(gridFleet);

                    // dead = remove unit
                    ButtonEvent eventDead = new ButtonEvent();
                    eventDead.IdHero = UnitIdDead;
                    eventDead.IdHeroVictim = UnitIdWin;
                    eventDead.NameEvent = ControllerConstant.DeadArmUnit;
                    ControllerButton.EventCallModel(ControllerConstant.DeadArmUnit,
                            ControllerConstant.DeadArmUnit,
                            eventDead);

                }

            }
            else
            {
                GetImprintVolley(ImprintVolleyList);

                //Salvo.
                if (Salvo)
                {
                    if (ImprintVolleyList != null)
                    {
                        Existense = unitTactic._armUnitShip.SalvoDamage(ImprintVolleyList);

                    }
                }
                // set damage.
                unitTactic.SetDeadDraw();
                unitTactic.SetDamageDraw(Existense, ImprintVolleyList);
                unitTactic._armUnitShip.StunDamage(Existense);
                //unitTactic.TextDamageAnim(Existense, ColorTextDamage.Red, null);





            }
        }
    }
    private void GetImprintVolley(List<ImprintVolley> ImprintVolley_ar)
    {

        foreach (ImprintVolley imprintVolley in ImprintVolley_ar)
        {
            if (imprintVolley.AffectHit != null)
            {

            }
        }

    }
    public Point GetPointMoveFleet(CommandStrategy commandStrategy)
    {
        int indiciumX = -(int)(commandStrategy.GridFleetOldPoint.X - commandStrategy.GridFleetNewPoint.X);
        int indiciumY = -(int)(commandStrategy.GridFleetOldPoint.Y - commandStrategy.GridFleetNewPoint.Y);
        return new Point(indiciumX, indiciumY);
    }
    */
}
