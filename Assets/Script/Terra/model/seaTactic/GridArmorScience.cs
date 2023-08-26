using System.Collections;
using System.Collections.Generic;


public class GridArmorScience 
{
	public string label = "Дубовые доски";
	public int data = 1;
	public int Item = 1;
	public int Cost = 1;
	public int Tonnage = 60;
	public int Level = 0;
	public int Armor = 20;
	public int Number = 1;
	public int Thick = 100;
	public string Abv = "Дуб";
	public int BonusArmor = 1;
	public int PercentStudy = 0;
	public int AbstractCost = 0;
	public int AbstractBacklog = 100;
	public string Help = "Броня из множества дубовых досок, ненадежна против современной артиллерии и слишком тяжела, но дешевая.";
	//public var icon;

	public GridArmorScience(
			string _label,
			string _Abv,
			int _data,
			int _Item,
			int _Cost,
			int _Tonnage,
			int _Level,
			int _Armor,
			int _Number,
			int _Thick,
			int _BonusArmor,
			int _PercentStudy,
			int _AbstractCost,
			int _AbstractBacklog,
			string _Help
	)
	{
		label = _label;
		data = _data;
		Item = _Item;
		Cost = _Cost;
		Tonnage = _Tonnage;
		Level = _Level;
		Armor = _Armor;
		Number = _Number;
		Thick = _Thick;
		Abv = _Abv;
		BonusArmor = _BonusArmor;
		PercentStudy = _PercentStudy;
		AbstractCost = _AbstractCost;
		AbstractBacklog = _AbstractBacklog;
		Help = _Help;



	}
}
