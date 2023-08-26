using System.Collections;
using System.Collections.Generic;


public class Country 
{
	public Country(int idCountry, int flagImage, int money, bool playerControl)
	{
		IdCountry = idCountry;
		FlagImage = flagImage;
		Money = money;
		PlayerControl = playerControl;
	}
	public int IdCountry = 0;
	public int FlagImage;
	public int Money = 30;
	public List<ContactState> Contact_ar;
	public bool PlayerControl;
}
