using System.Collections;
using System.Collections.Generic;


public class ButtonEvent 
{
	public Point Point { set; get; }
    public List<Point> PathGoto_ar;
	public GridFleet HeroFleet;
	public GridFleet VictimFleet;
	public Island Island;
	public int TypeEventId;
	public bool NotFlagDisplay;
	public int UnitId;
	public string NameEvent { set; get; }
	public bool MoveAI;
	public int IdHero;
	public int IdHeroVictim;
	public int SpotX { set; get; }
    public int SpotY { set; get; }
    public int IdHeroFiend;
	public int IdHeroPlayer;
	public bool LongRange;
	public float DownMouseX;
	public float DownMouseY;
}
