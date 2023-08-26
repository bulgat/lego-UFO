using System.Collections;
using System.Collections.Generic;

public class AnimationMove : BasicAnimationMove
{
    /*
    private PlayMusic _playMusic;
    private bool _firstTick = false;
    private GameObject _moveObject;

    public AnimationMove()
    {
        _playMusic = new PlayMusic();
    }
    public CommandStrategy GetFirstCommand()
    {


        foreach (var commandStrategy in MapWorldModel.GetCommandCapture())
        {
            if (MapWorldModel.GetCommandCaptureFirst().GridFleetOldPoint != null)
            {
                Debug.Log(commandStrategy.Id + "   h   CommandCa Id = " + commandStrategy.GridFleet.GetShipNameFirst().GetFirstUnit().Id + " old  x=" + MapWorldModel.GetCommandCaptureFirst().GridFleetOldPoint.X +
                    " new X = " + MapWorldModel.GetCommandCaptureFirst().GridFleetNewPoint.X);
            }
        }

        // animation capture island
        return MapWorldModel.GetCommandCaptureFirst();
    }

    public CommandStrategy AnimationCommand(int StageWidthX, long Tick,
            CommandStrategy commandStrategy,
            LoadBibleImage _loadBibleImage, int _width,
            AnimCaptureIsland _animCaptureIsland,
            CreateHero _createHero, float SlipX, float SlipY,
            List<GridCrewScience> BasaPurchaseUnitScience_ar,
            List<GameObject> SceneList, int SadIslandId, int SelectAttackId, List<GameObject> UnitHeroGameObjectList
            )
    {



        if (_tickReal + _continuance > Tick)
        {

            if (_tickReal + 1 > Tick)
            {

            }
            else
            {

                if (commandStrategy != null)
                {

                    if (commandStrategy.ViewActor_ar != null)
                    {

                        if (commandStrategy.LongRange == false)
                        {

                            GameObject heroFleet = GetUnitGameObject(UnitHeroGameObjectList, commandStrategy.GridFleet.GetId());
                            float heroZ = heroFleet.transform.position.z;

                            GameObject tileOld = GetTileGameObject(SceneList, (int)commandStrategy.GridFleetOldPoint.X, (int)commandStrategy.GridFleetOldPoint.Y);
                            GameObject tileNew = GetTileGameObject(SceneList, (int)commandStrategy.GridFleetNewPoint.X, (int)commandStrategy.GridFleetNewPoint.Y);
                            //float speed = 1.13f;
                     
                            //float step = speedUnit * Time.deltaTime;
                            heroFleet.transform.position = Vector3.MoveTowards(
                                new Vector3(heroFleet.transform.position.x, heroFleet.transform.position.y, heroZ),
                                new Vector3(tileNew.transform.position.x, tileNew.transform.position.y, heroZ),
                                GetStep());
                            // correct z

                        }
                    }
                }
            }
        }

        if (_tickReal + _continuance <= Tick)
        {

            if (commandStrategy != null)
            {
                GameObject heroFleet = SetPostionFleet(UnitHeroGameObjectList, commandStrategy.GridFleet.GetId());



                ControllerButton.SetCommandPerform(commandStrategy.Id);

                _animCaptureIsland.ResetCapture();

                MapWorldModel.SetChangeStateView(true);
                ControllerButton.UnlockBlock();

                SetPostionFleetTile(commandStrategy.GridFleet, UnitHeroGameObjectList,
         SceneList, heroFleet);

                commandStrategy = null;

            }
            _firstTick = false;
        }
        if (_tickReal + _continuance < Tick)
        {
            ControllerButton.UnlockBlock();
            _firstTick = false;
        }

        return commandStrategy;
    }
    private GameObject SetPostionFleet(List<GameObject> UnitHeroGameObjectList, int FleetId)
    {
        GameObject heroFleet = GetUnitGameObject(UnitHeroGameObjectList, FleetId);

        return heroFleet;
    }
    private void SetPostionFleetTile(GridFleet GridFleet, List<GameObject> UnitHeroGameObjectList,
        List<GameObject> SceneList, GameObject heroFleet)
    {
        float heroZ = heroFleet.transform.position.z;
        GameObject tile = GetTileGameObject(SceneList, (int)GridFleet.SpotX, (int)GridFleet.SpotY);
        heroFleet.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y, heroZ);
    }
    public void SetAllFleetPosition(List<GameObject> UnitHeroGameObjectList, List<GameObject> SceneList)
    {
        List<GridFleet> HeroFleetList = MapWorldModel._prototypeHeroDemo.GetHeroFleet();
        foreach (GridFleet fleet in HeroFleetList)
        {
            GameObject heroFleet = SetPostionFleet(UnitHeroGameObjectList, fleet.GetId());
            SetPostionFleetTile(fleet, UnitHeroGameObjectList,
         SceneList, heroFleet);
        }
    }

    

 


    public void SelectAttackFleet(LoadBibleImage _loadBibleImage,
        AnimCaptureIsland _animCaptureIsland, int StageWidthX,
        CommandStrategy CommandStrategy, float SlipX, float SlipY, List<GameObject> SceneList, int SadIslandId)
    {

        List<GameObject> actor_ar = DeleteActorImage.GetActorWithName(
                    SceneList,
                    SadIslandId);

        _animCaptureIsland.DrawCapture(StageWidthX,
                                    CommandStrategy.GridFleetVictim.SpotX,
                                    CommandStrategy.GridFleetVictim.SpotY,
                                    actor_ar[0], SlipX, SlipY);

        _playMusic.PlayMusicOperative(MusicBibleConstant.AlertAttack);

    }

    public void CaptureIsland(LoadBibleImage _loadBibleImage,
            AnimCaptureIsland _animCaptureIsland, int StageWidthX,
            CommandStrategy CommandStrategy, float SlipX, float SlipY, List<GameObject> SceneList, int SadIslandId)
    {
        List<GameObject> actor_ar = DeleteActorImage.GetActorWithName(
                SceneList,
                SadIslandId);

        _animCaptureIsland.DrawCapture(StageWidthX,
                CommandStrategy.CaptureIsland.SpotX,
                CommandStrategy.CaptureIsland.SpotY,
                actor_ar[0], SlipX, SlipY
                );
        _playMusic.PlayMusicOperative(MusicBibleConstant.Radio);
    }
    public void CaptureIslandHide(AnimCaptureIsland _animCaptureIsland, List<GameObject> SceneList, int SadIslandId)
    {
        List<GameObject> actor_ar = DeleteActorImage.GetActorWithName(
                SceneList,
                SadIslandId);
        _animCaptureIsland.DrawCaptureHide(actor_ar[0]);
    }
    public void CreateFleet(LoadBibleImage _loadBibleImage,
            AnimCaptureIsland _animCaptureIsland, int StageWidthX,
            CommandStrategy commandStrategy, float SlipX, float SlipY,
             int _width, List<GridCrewScience> BasaPurchaseUnitScience_ar)
    {
        GameObject actorOne = _animCaptureIsland.DrawCreateFleet(
                null,
                _width,
                commandStrategy.GridFleet.SpotX, commandStrategy.GridFleet.SpotY,
                commandStrategy.GridFleet,
                BattleModel.GetUpheavalX(), BattleModel.GetUpheavalY(), BasaPurchaseUnitScience_ar);
        //stage.addActor(actorOne);
    }
    public void MoveFleet(CommandStrategy commandStrategy, AnimCaptureIsland _animCaptureIsland,
            LoadBibleImage _loadBibleImage, int _width,
            CreateHero _createHero, List<GridCrewScience> BasaPurchaseUnitScience_ar,
            List<GameObject> SceneGameObjectList)
    {
        if (commandStrategy.NameCommand == CommandStrategy.Type.MoveFleet)
        {
            _playMusic.PlayMusicOperative(
                    commandStrategy.GridFleet.GetShipNameFirst().GetFirstUnit().GetUnitScience().SoundMove);
        }
        commandStrategy.ViewActor_ar = new List<GameObject>();



        List<GameObject> actor_ar = DeleteActorImage.GetActorWithName(
                SceneGameObjectList,
                commandStrategy.GridFleet.GetId());



        List<GameObject> heroImage_ar = new List<GameObject>();

    


        if (actor_ar.Count != 0)
        {
        
        }
    }
    public float GetOldX(CommandStrategy commandStrategy)
    {
        return -(commandStrategy.GridFleetOldPoint.X - commandStrategy.GridFleetNewPoint.X);
    }
    public float GetOldY(CommandStrategy commandStrategy)
    {
        return -(commandStrategy.GridFleetOldPoint.Y - commandStrategy.GridFleetNewPoint.Y);
    }
*/
}
