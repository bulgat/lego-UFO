using System.Collections;
using System.Collections.Generic;


public class ContactState 
{
	public ContactState(int FlagId, bool peace)
	{
		flagId = FlagId;
		Peace = peace;
	}
	public bool Peace;
	public int Endurance;
	public int flagId;
}
