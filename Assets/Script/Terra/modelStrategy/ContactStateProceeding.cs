using System.Collections;
using System.Collections.Generic;


public class ContactStateProceeding 
{
	public static void InitContact(List<Country> DispositionCountry_ar)
	{

		foreach (Country country in DispositionCountry_ar)
		{
			country.Contact_ar = new List<ContactState>();

			// пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅпїЅпїЅ.
			foreach (Country enemyCountry in DispositionCountry_ar)
			{
				if (country.IdCountry != enemyCountry.IdCountry)
				{
					country.Contact_ar.Add(new ContactState(enemyCountry.IdCountry, true));
				}
			}

		}
	}
	public static void SetContactPeace(List<Country> DispositionCountry_ar,
			Point flagIdPoint, bool Peace)
	{

		List<ContactState> contactState_ar = GetContactArray(DispositionCountry_ar, flagIdPoint);
		foreach (ContactState contactState in contactState_ar)
		{
			contactState.Peace = Peace;
		}
	}
	private static List<ContactState> GetContactArray(List<Country> DispositionCountry_ar, Point flagIdPoint)
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
	// пїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ, пїЅпїЅ пїЅпїЅ пїЅпїЅ.
	public static Country GetDispositionCountry(List<Country> DispositionCountry_ar,
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
	public static Country GetPlayerCountryFollow(List<Country> DispositionCountry_ar,
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
	public static bool GetContactPeace(List<Country> DispositionCountry_ar,
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

	// пїЅпїЅпїЅпїЅпїЅ-пїЅпїЅ пїЅ пїЅпїЅпїЅпїЅ пїЅ пїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅпїЅ пїЅпїЅпїЅпїЅпїЅ?
	public static bool ContactGlobalPeace(Country Country)
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
