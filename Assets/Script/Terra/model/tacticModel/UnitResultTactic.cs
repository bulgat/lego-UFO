using System.Collections;
using System.Collections.Generic;

public class UnitResultTactic 
{
	public UnitResultTactic(
			bool attackPlayer,
	bool deadPlayer,
	int unitIdWin,
	int unitIdDead,
	ArmUnit unitWinPsevdo,
	ArmUnit unitDeadPsevdo,
	int existense,
			List<ArmUnit> crewPLayer_ar,
			List<ArmUnit> crewFiend_ar,
			ArmUnit unitPlayer,
			ArmUnit unitFiend,
			int playerMeleeFull,
			int fiendMeleeFull,
			bool blockDead,
			bool Salvo,
			List<ImprintVolley> ImprintVolleyList
			)
	{
		this.AttackPlayer = attackPlayer;
		this.DeadPlayer = deadPlayer;
		this.UnitIdWin = unitIdWin;
		this.UnitIdDead = unitIdDead;
		this.UnitWinPsevdo = unitWinPsevdo;
		this.UnitDeadPsevdo = unitDeadPsevdo;

		this.Existense = existense;
		this.CrewFPlayer_ar = crewPLayer_ar;
		this.CrewFiend_ar = crewFiend_ar;
		this.UnitPlayer = unitPlayer;
		this.UnitFiend = unitFiend;
		this.PlayerMeleeFull = playerMeleeFull;
		this.FiendMeleeFull = fiendMeleeFull;
		this.BlockDead = blockDead;
		this.Salvo = Salvo;
		this.ImprintVolleyList = ImprintVolleyList;
	}

	public bool AttackPlayer;
	public bool DeadPlayer;
	public int UnitIdWin;
	public int UnitIdDead;
	public ArmUnit UnitWinPsevdo;
	public ArmUnit UnitDeadPsevdo;

	public ArmUnit UnitPlayer;
	public ArmUnit UnitFiend;

	public int Existense;
	public int Select_Unit_Player;
	public int Select_Unit_Fiend;
	public List<ArmUnit> CrewFPlayer_ar;
	public List<ArmUnit> CrewFiend_ar;
	public int PlayerMeleeFull;
	public int FiendMeleeFull;
	public bool BlockDead;

	// salvo.
	public bool Salvo;
	public List<ImprintVolley> ImprintVolleyList;
}
