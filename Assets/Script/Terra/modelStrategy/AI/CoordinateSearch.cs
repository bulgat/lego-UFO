using System.Collections;
using System.Collections.Generic;


public class CoordinateSearch 
{
	public static List<Point> GetXmapNear(bool AddCenter)
	{

		List<Point> _nearMap_ar = new List<Point>();
		_nearMap_ar.Add(new Point(1, -1));
		_nearMap_ar.Add(new Point(1, 0));
		_nearMap_ar.Add(new Point(1, 1));
		_nearMap_ar.Add(new Point(0, -1));
		//_nearMap_ar.add(new Point(0,0));
		_nearMap_ar.Add(new Point(0, 1));
		_nearMap_ar.Add(new Point(-1, -1));
		_nearMap_ar.Add(new Point(-1, 0));
		_nearMap_ar.Add(new Point(-1, 1));
		_nearMap_ar.Add(new Point(-2, 2));
		_nearMap_ar.Add(new Point(-1, 2));
		_nearMap_ar.Add(new Point(0, 2));
		_nearMap_ar.Add(new Point(1, 2));
		_nearMap_ar.Add(new Point(2, 2));
		_nearMap_ar.Add(new Point(2, 1));
		_nearMap_ar.Add(new Point(2, 0));
		_nearMap_ar.Add(new Point(2, -1));
		_nearMap_ar.Add(new Point(2, -2));
		_nearMap_ar.Add(new Point(1, -2));
		_nearMap_ar.Add(new Point(0, -2));
		_nearMap_ar.Add(new Point(-1, -2));
		_nearMap_ar.Add(new Point(-2, -2));
		_nearMap_ar.Add(new Point(-2, -1));
		_nearMap_ar.Add(new Point(-2, 0));
		_nearMap_ar.Add(new Point(-2, 1));
		if (AddCenter)
		{
			_nearMap_ar.AddRange(GetXmapNearCenter());
		}
		return _nearMap_ar;
	}
	public static List<Point> GetMapFlagIslandArray()
	{
		List<Point> mapFlagIsland_ar = new List<Point>();
		mapFlagIsland_ar.Add(new Point(1, -1));
		mapFlagIsland_ar.Add(new Point(1, 0));
		mapFlagIsland_ar.Add(new Point(1, 1));
		mapFlagIsland_ar.Add(new Point(0, -1));
		mapFlagIsland_ar.Add(new Point(0, 1));
		mapFlagIsland_ar.Add(new Point(-1, -1));
		mapFlagIsland_ar.Add(new Point(-1, 0));
		mapFlagIsland_ar.Add(new Point(-1, 1));
		mapFlagIsland_ar.Add(new Point(1, 1));

		return mapFlagIsland_ar;
	}
	public static List<Point> GetXmapNearCenter()
	{
		List<Point> mapFlagIsland_ar = GetMapFlagIslandArray();
		mapFlagIsland_ar.Add(new Point(0, 0));

		return mapFlagIsland_ar;
	}
}
