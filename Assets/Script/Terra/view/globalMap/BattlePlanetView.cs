using System.Collections;
using System.Collections.Generic;
using ZedAngular.Model.Terra.scenario;

public class BattlePlanetView 
{
    CreateTileMap _createTileMap;
    private static BattlePlanetView _BattlePlanetView;
    //private static CommandStrategy _CommandStrategy;
    
    public BattlePlanetView(BattlePlanetModel battlePlanetModel)
    {
        BattlePlanetModel._initGlobalParams = new InitGlobalParams(battlePlanetModel);
        //new MapWorldStartGame().StartGameFirstReset(new VictoryStipulation(), new FactoryScenario().GetFactoryScenario(0), battlePlanetModel);

        
        _createTileMap = new CreateTileMap();


        CreateTileMap();

    }
    public static BattlePlanetView GetBattlePlanetViewSingleton()
    {
        if (_BattlePlanetView == null)
        {
            // System.Diagnostics.Debug.WriteLine(" +  SpotX  = "+ kol);
            _BattlePlanetView = new BattlePlanetView(BattlePlanetModel.GetBattlePlanetModelSingleton());
        }
        return _BattlePlanetView;
    }
    


    private void CreateTileMap()
    {
        
        
        this._createTileMap.DrawTileMap(BattlePlanetModel.GetBattlePlanetModelSingleton().GetGridTileList());
                
    }
}
