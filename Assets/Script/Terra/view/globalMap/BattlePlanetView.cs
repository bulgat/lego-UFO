using System.Collections;
using System.Collections.Generic;


public class BattlePlanetView 
{
    CreateTileMap _createTileMap;
    private static BattlePlanetView _BattlePlanetView;
    private static CommandStrategy _CommandStrategy;

    public BattlePlanetView()
    {

        MapWorldStartGame.StartGameFirstReset(new VictoryStipulation());

        
        _createTileMap = new CreateTileMap();


        DrawAllMap(0, 0);

        

    }
    public BattlePlanetModel GetMapWorldStartGame()
    {
       // BattlePlanetModel _BattlePlanetModel
        return BattlePlanetModel.GetBattlePlanetModelSingleton();
    }
    public CommandStrategy GetCommandStrategy() {
        return _CommandStrategy;
    }
    public void SetCommandStrategy(CommandStrategy commandStrategy)
    {
        _CommandStrategy = commandStrategy;
    }
    public static bool NullBattlePlanetView()
    {
        return _BattlePlanetView==null;
    }
    public static BattlePlanetView GetBattlePlanetViewSingleton()
    {
        if (_BattlePlanetView == null) {
            _BattlePlanetView = new BattlePlanetView();
        }
        return _BattlePlanetView;
    }

        private void DrawAllMap(float WidthSceneAll, int WidthMap)
    {
        CreateTileMap(WidthMap,  BattlePlanetModel.GetGridTileList());

    }
    private void CreateTileMap(int WidthMap,  List<GridTileBar> GridTile_ar)
    {
        
        
        this._createTileMap.DrawTileMap((int)WidthMap, GridTile_ar,
                BattleModel.GetUpheavalX(), BattleModel.GetUpheavalY(), null,  false);
                
    }
}
