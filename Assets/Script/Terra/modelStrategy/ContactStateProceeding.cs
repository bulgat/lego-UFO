using System.Collections;
using System.Collections.Generic;


public class ContactStateProceeding 
{
	public void InitContact(BattlePlanetModel battlePlanetModel)
	{
		if (battlePlanetModel.DispositionCountry_ar == null)
		{
			return;
		}
		foreach (Country country in battlePlanetModel.DispositionCountry_ar)
		{
			country.Contact_ar = new List<ContactState>();


			foreach (Country enemyCountry in battlePlanetModel.DispositionCountry_ar)
			{
				if (country.IdCountry != enemyCountry.IdCountry)
				{
					country.Contact_ar.Add(new ContactState(enemyCountry.IdCountry, true));
				}
			}

		}
	}
	public void SetContactPeace(List<Country> DispositionCountry_ar,
			Point flagIdPoint, bool Peace)
	{

		List<ContactState> contactState_ar = GetContactArray(DispositionCountry_ar, flagIdPoint);
		foreach (ContactState contactState in contactState_ar)
		{
			contactState.Peace = Peace;
		}
	}
	private List<ContactState> GetContactArray(List<Country> DispositionCountry_ar, Point flagIdPoint)
	{
		int[] flagId_ar = { (int)flagIdPoint.X, (int)flagIdPoint.Y };
		List<ContactState> contactState_ar = new List<ContactState>();
		for (int i = 0; i < flagId_ar.Length; i++)
		{

			Country country = GetDispositionCountry(DispositionCountry_ar,
					flagId_ar[i]);

			if (country != null)
			{

				foreach (ContactState contactState in country.Contact_ar)
				{

					for (int z = 0; z < flagId_ar.Length; z++)
					{
						if (contactState.flagId == flagId_ar[z])
						{

							contactState_ar.Add(contactState);
						}
					}

				}
			}

		}
		return contactState_ar;
	}

	public Country GetDispositionCountry(List<Country> DispositionCountry_ar,
			int flagId)
	{
		foreach (Country country in DispositionCountry_ar)
		{
			if (country.IdCountry == flagId)
			{
				return country;
			}
		}
		return null;
	}
	public Country GetPlayerCountryFollow(List<Country> DispositionCountry_ar,
			int flagId)
	{
		foreach (Country country in DispositionCountry_ar)
		{
			if (country.PlayerControl == true)
			{
				if (country.IdCountry != flagId)
				{
					return country;
				}
			}
		}
		return null;
	}
	public bool GetContactPeace(List<Country> DispositionCountry_ar,
			Point flagIdPoint)
	{
		List<ContactState> contactState_ar = GetContactArray(DispositionCountry_ar, flagIdPoint);
		foreach (ContactState contactState in contactState_ar)
		{
			if (contactState.Peace)
			{
				return true;
			};
		}

		return false;
	}

	public bool ContactGlobalPeace(Country Country)
	{
		foreach (ContactState contactState in Country.Contact_ar)
		{
			if (contactState.Peace == false)
			{
				return false;
			}
		}
		return true;
	}
}
