using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RTS {
	public enum CursorState { Select, Move, Attack, PanLeft, PanRight, PanUp, PanDown, Harvest }
	public enum CommandState { Turn, ClickPlayerShip, ClickTile, AttackShip, BattleInterface, Message, BuyShip,
		BlockScroll, unBlockScroll, BombPlanet, PlanetChooter, PlanetLanding, GotoPlanet,
		ClickFleet,LeftChangeShipFleet,RightChangeShipFleet,EndAttackShip,InitGameLevel, CameraSetUpBattle,
        PlanetPanel,InitCustomGameLevel,MessageGlobalWin,DestroyGameLevel,
        InitStickGameLevel,AttackTacticStick,BuyUnitStickBattle, BuyUnitStickBattleFiend, StickPlayerAttackBase,
        StickPlayerDefenceBase, GreetingPlayerMenu
    };

    public enum CommandSend
    { fleetOne, fleetTwo, typeUnit };

    public enum ImageBible
    {peasant,sword,crossbow,knight,worker,longSword };
    public enum ImageBigBible
    { win, unwin };
    public enum ImageDuty
    { swordGold, shieldGold,shield_0, shield_1, shield_2, shield_3, shield_4 };


    public enum NameUnit
    { sword, pikeman, crossbow,horse,building,labor,Ore,Repository,longSword };

    public enum ShipState { Battle, Transport};
	public enum SoundItem { soundAttack, soundCount, soundDead,soundArchery };
	public enum tagObject { ship, shipSink};

    public class TypeUnitSend
    {
        public int typeUnit;
        public List<int> unitArray;

    }

}