using System.Collections;
using System.Collections.Generic;


public class ViewTerraAnimMove 
{
	/*
    AnimationMove _animationMove;
    void Start()
    {
         _animationMove = new AnimationMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationCommand(BattlePlanetView BattlePlanetView,
        int StageWidthX, long Tick,
            CommandStrategy commandStrategy,
            //LoadBibleImage _loadBibleImage,
            int width,
            AnimCaptureIsland _animCaptureIsland,
            CreateHero _createHero, float SlipX, float SlipY,
            List<GridCrewScience> BasaPurchaseUnitScience_ar,
            List<GameObject> SceneList, int SadIslandId, int SelectAttackId, 
			List<GameObject> UnitHeroGameObjectList
			)
    {

		

		if (MapWorldModel.GetCommandCapture().Count > 0)
        {
            if (commandStrategy == null)
            {
                // animation capture island
                commandStrategy = _animationMove.GetFirstCommand();

                _animationMove._tickReal = Tick;

                ControllerButton.SetBlock();
                //StartCoroutine(PrintAnimation(""));
//correct
		_animationMove.SetAllFleetPosition(UnitHeroGameObjectList, SceneList);
                {
					
						//cock
						{

							//_firstTick = true;
							if (commandStrategy != null)
							{
							
							if (commandStrategy.NameCommand == CommandStrategy.Type.CaptureIsland)
								{


								// MoveFleet

								//MoveFleet(commandStrategy, _animCaptureIsland,
								//		_loadBibleImage, _width, _createHero, BasaPurchaseUnitScience_ar, SceneList);


								_animationMove.CaptureIsland(null,
											_animCaptureIsland, StageWidthX,
											commandStrategy, SlipX, SlipY, SceneList, SadIslandId);
								}
								else
								{
								_animationMove.CaptureIslandHide(_animCaptureIsland, SceneList, SadIslandId);
								}
								if (commandStrategy.NameCommand == CommandStrategy.Type.CreateFleet)
								{

								_animationMove.CreateFleet(null,
											 _animCaptureIsland, StageWidthX,
											commandStrategy, SlipX, SlipY,
											width, BasaPurchaseUnitScience_ar);
								}

								// MoveFleet
								if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet ||
										commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
								{



									

									if (commandStrategy.NameCommand == CommandStrategy.Type.AttackFleet)
									{

									_animationMove.SelectAttackFleet(null,
											_animCaptureIsland, StageWidthX,
											commandStrategy, SlipX, SlipY, SceneList, SelectAttackId);




										//SelectAttack
										//empty
										GameObject NameImageSelectAttack = new GameObject();


										_animCaptureIsland.DrawCapture(StageWidthX,
												commandStrategy.GridFleetVictim.SpotX,
												commandStrategy.GridFleetVictim.SpotY,
												NameImageSelectAttack,
												SlipX, SlipY);

										//MapWorldModel.RemoveCommandStrategy(commandStrategy);
										//_playMusic.PlayMusicOperative(MusicBibleConstant.AlertAttack);

									}
									else
									{
									_animationMove.CaptureIslandHide(_animCaptureIsland, SceneList, SelectAttackId);
									}

								// MoveFleet
								_animationMove.MoveFleet(commandStrategy, _animCaptureIsland,
											null, width, _createHero, BasaPurchaseUnitScience_ar, SceneList);



								}
							}
						}
					//////////////////////////
						// animation
						{
						
							if (commandStrategy != null)
							{

							}
							
							///////////////////
						}
					

				}




            }
        }
		



		BattlePlanetView.SetCommandStrategy(_animationMove.AnimationCommand(StageWidthX, Tick,
      commandStrategy,
            //BattlePlanetView.GetCommandStrategy(),
     null, width, _animCaptureIsland, _createHero,
     SlipX, SlipY,
     BattlePlanetModel.GetBasaPurchaseUnitScience(),
     SceneList, SadIslandId, SelectAttackId, UnitHeroGameObjectList
	 ));
    }
	*/
 }
