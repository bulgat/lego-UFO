using System.Collections;
using System.Collections.Generic;


public class TimeSalvoConstant
{
	public void GetBasaModuleScience()
	{

	}
	public BasaGoalShip GetBasaGoalTypeShip(int Id)
	{
		List<BasaGoalShip> BasaGoalShip_ar = new List<BasaGoalShip>();
		BasaGoalShip basaGoalShip = new BasaGoalShip(Id);
		BasaGoalShip_ar.Add(basaGoalShip);
		foreach (BasaGoalShip goalShip in BasaGoalShip_ar)
		{
			//if (goalShip)
		}

		return basaGoalShip;
	}


	public List<CannonAmmunition> GetCannonAmmunition()
	{
		List<CannonAmmunition> CannonAmmunitionList = new List<CannonAmmunition>();
		CannonAmmunitionList.Add(new CannonAmmunition(0, 1, 4, 2, 5990, 15, 4, 8, false, 0, 0, false, false, "Фальконет", 400, 50));
		CannonAmmunitionList.Add(new CannonAmmunition(1, 5, 8, 2, 1990, 22, 9, 10, false, 1, 1, false, false, "Пушка 18 фунтов", 80, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(2, 8, 15, 2, 1990, 65, 10, 23, true, 2, 2, false, false, "Камнемет", 70, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(3, 1, 4, 4, 1990, 16, 4, 8, false, 0, 0, false, false, "Полупушка", 100, 50));
		CannonAmmunitionList.Add(new CannonAmmunition(4, 5, 5, 4, 1990, 63, 9, 22, false, 1, 3, false, false, "Чугунная 24 фунтовая пушка", 90, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(5, 8, 8, 4, 1990, 105, 10, 33, false, 2, 4, false, false, "Чугунная 40 фунтовая пушка", 90, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(6, 5, 8, 2, 1990, 82, 10, 20, false, 1, 3, true, false, "40 фунтовая карронада", 90, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(7, 10, 10, 3, 1990, 714, 3, 33, false, 2, 5, true, false, "68 фунтовая бомбическая пушка", 80, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(8, 20, 11, 4, 1700, 217, 60, 115, true, 2, 6, true, false, "10 дюймовая гладкоствольная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(9, 10, 10, 6, 1800, 139, 15, 73, true, 1, 7, true, false, "6 дюймовая нарезная казнозарядная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(10, 10, 15, 6, 1800, 153, 20, 82, true, 1, 8, true, false, "9 дюймовая нарезная казнозарядная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(11, 30, 20, 4, 1700, 285, 100, 150, true, 2, 9, true, false, "12 дюймовая гладкоствольная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(12, 40, 30, 4, 1700, 405, 200, 210, true, 2, 10, true, false, "15 дюймовая гладкоствольная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(13, 2, 1, 6, 1800, 60, 4, 34, false, 0, 0, false, false, "47-мм карчечница Гочкинса", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(14, 1, 2, 6, 1800, 62, 7, 36, false, 0, 0, false, false, "47-мм пушка Гочкинса", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(15, 30, 25, 6, 1800, 360, 70, 165, true, 2, 11, true, false, "12 дюймовая нарезная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(16, 40, 39, 6, 1800, 735, 200, 330, true, 2, 10, true, false, "15 дюймовая нарезная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(17, 15, 3, 11, 1900, 84, 25, 42, true, 1, 7, false, false, "75 mm/50 калиберная  пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(18, 17, 3, 11, 1900, 202, 35, 95, true, 1, 8, true, false, "120 mm/45 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(19, 18, 4, 11, 1900, 375, 60, 170, true, 1, 9, true, false, "152 mm/45 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(20, 19, 5, 11, 1900, 465, 95, 310, true, 1, 10, true, false, "202 mm/45 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(21, 22, 7, 11, 1900, 570, 135, 460, true, 2, 11, true, false, "252 mm/45 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(22, 25, 9, 11, 1900, 825, 165, 650, true, 2, 12, true, false, "303 mm/40 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(23, 2, 1, 6, 1800, 60, 4, 34, false, 0, 1, false, true, "37-мм пулемет Максима", 100, 20));
		CannonAmmunitionList.Add(new CannonAmmunition(24, 16, 3, 12, 1900, 247, 30, 115, true, 1, 12, false, false, "100 mm/60 калиберная пушка", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(25, 2, 3, 6, 1800, 450, 100, 34, false, 0, 2, false, true, "76-мм зенитная пушка Лендера", 100, 40));
		CannonAmmunitionList.Add(new CannonAmmunition(26, 30, 9, 15, 1900, 1125, 265, 750, true, 2, 13, true, false, "356/52 калиберная mm пушка", 100, 40));
		return CannonAmmunitionList;
	}
	private List<GridArmorScience> GetArmor()
	{
		List<GridArmorScience> BasaArmorScience = new List<GridArmorScience>();

		BasaArmorScience.Add(new GridArmorScience("Дубовые доски", "Дуб", 1, 1, 1, 60, 0, 20, 1, 100, 1, 0, 0, 0, "Броня из множества дубовых досок, ненадежна против современной артиллерии и слишком тяжела, но дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 100 мм", "Лист 100мм", 2, 2, 2, 30, 0, 40, 2, 100, 2, 0, 1, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 150 мм", "Лист 150мм", 3, 3, 3, 45, 0, 60, 3, 150, 3, 0, 2, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 200 мм", "Лист 200мм", 4, 4, 4, 60, 0, 80, 3, 200, 4, 0, 3, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 250 мм", "Лист 250мм", 5, 4, 5, 75, 0, 100, 5, 250, 5, 0, 4, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 300 мм", "Лист 300мм", 6, 4, 6, 90, 0, 120, 6, 300, 6, 0, 5, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));
		BasaArmorScience.Add(new GridArmorScience("Пакет листов 350 мм", "Лист 350мм", 7, 4, 7, 105, 0, 140, 7, 350, 7, 0, 6, 0, "Броня из множества листов железа, скрепленная болтами, все на что была способна индустрия страны в те времена. Надежна против старой артиллерии, и  дешевая."));

		BasaArmorScience.Add(new GridArmorScience("Железо 100 мм", "Желез. 100мм", 8, 4, 4, 30, 0, 50, 8, 100, 3, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));
		BasaArmorScience.Add(new GridArmorScience("Железо 150 мм", "Желез. 150мм", 9, 4, 6, 45, 0, 75, 9, 150, 4, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));
		BasaArmorScience.Add(new GridArmorScience("Железо 200 мм", "Желез. 200мм", 10, 4, 8, 60, 0, 100, 10, 200, 6, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));
		BasaArmorScience.Add(new GridArmorScience("Железо 250 мм", "Желез. 250мм", 11, 4, 10, 75, 0, 125, 11, 250, 7, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));
		BasaArmorScience.Add(new GridArmorScience("Железо 300 мм", "Желез. 300мм", 12, 4, 12, 90, 0, 150, 12, 300, 9, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));
		BasaArmorScience.Add(new GridArmorScience("Железо 350 мм", "Желез. 350мм", 13, 4, 14, 105, 0, 175, 13, 350, 10, 0, 6, 0, "Броня из цельного листа железа. Надежна против гладкоствольной артиллерии."));

		BasaArmorScience.Add(new GridArmorScience("Кованное железо 100 мм", "Ков. 100мм", 14, 4, 6, 30, 0, 80, 14, 100, 6, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));
		BasaArmorScience.Add(new GridArmorScience("Кованное железо 150 мм", "Ков. 150мм", 15, 4, 9, 45, 0, 120, 15, 150, 9, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));
		BasaArmorScience.Add(new GridArmorScience("Кованное железо 200 мм", "Ков. 200мм", 16, 4, 12, 60, 0, 160, 16, 200, 12, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));
		BasaArmorScience.Add(new GridArmorScience("Кованное железо 250 мм", "Ков. 250мм", 17, 4, 15, 75, 0, 200, 17, 250, 15, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));
		BasaArmorScience.Add(new GridArmorScience("Кованное железо 300 мм", "Ков. 300мм", 18, 4, 18, 90, 0, 240, 18, 300, 18, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));
		BasaArmorScience.Add(new GridArmorScience("Кованное железо 350 мм", "Ков. 350мм", 19, 4, 21, 105, 0, 280, 19, 350, 19, 0, 6, 0, "Броня из прокованного листа железа. Надежна против артиллерии, но дорогая."));

		BasaArmorScience.Add(new GridArmorScience("Сэндвич 100 мм", "Сэнд. 100мм", 20, 4, 6, 25, 0, 90, 20, 100, 6, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 150 мм", "Сэнд. 150мм", 21, 4, 9, 35, 0, 135, 21, 150, 9, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 200 мм", "Сэнд. 200мм", 22, 4, 12, 45, 0, 180, 22, 200, 12, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 250 мм", "Сэнд. 250мм", 23, 4, 15, 55, 0, 225, 23, 250, 15, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 300 мм", "Сэнд. 300мм", 24, 4, 18, 65, 0, 270, 24, 300, 18, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 350 мм", "Сэнд. 350мм", 25, 4, 21, 75, 0, 315, 25, 350, 21, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 400 мм", "Сэнд. 400мм", 26, 4, 24, 85, 0, 360, 26, 400, 24, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 450 мм", "Сэнд. 450мм", 27, 4, 27, 95, 0, 405, 27, 450, 27, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 500 мм", "Сэнд. 500мм", 28, 4, 30, 105, 0, 450, 28, 500, 30, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 550 мм", "Сэнд. 550мм", 29, 4, 33, 115, 0, 495, 29, 550, 33, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		BasaArmorScience.Add(new GridArmorScience("Сэндвич 600 мм", "Сэнд. 600мм", 30, 4, 36, 125, 0, 540, 30, 600, 36, 0, 6, 0, "Броня типа Сэндвич: сверху стальная пластина, легко раскалывающая, в середине тиковая деревянная прокладка, снизу кованное мягкое железо. Такая броня оказалась прочнее чем такая же из сварного железа."));
		
		return BasaArmorScience;

	}
}
