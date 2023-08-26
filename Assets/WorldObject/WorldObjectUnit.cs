using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using System.Linq;

//[RequireComponent(typeof(AudioSource))]
public class WorldObjectUnit : MonoBehaviour {

    public enum NameGames { Level,Rts,stickBattle }

    private NameGames StateGames;
	public string objectName;

	public int  maxHitPoints;
	public int hitPoints;
    public int Stock;

    public bool fiend = false;

	public Player player;
	public int idFleet;
	protected bool _selectShip = false;

	protected string[] actions = {};
	public bool currentlySelected = false;

	protected Bounds selectionBounds;
	protected Rect playingArea = new Rect(0.0f, 0.0f, 0.0f, 0.0f);

	protected GUIStyle healthStyle = new GUIStyle();
	protected GUIStyle damageStyle = new GUIStyle();

	protected float healthPercentage = 1.0f;

    protected WorldObjectUnit target = null;
	

	//10f
    // Расстояния с которого, можно начинать атаку.
	public float weaponRange = 10.0f;
    public int weaponDamage = 1;

    private float stopDistanceOffset = 2.5f;

	private bool movingIntoPosition = false;
	protected bool aiming = false;
	public float weaponRechargeTime = 1.0f;
	private float currentWeaponChargeTime;
	public float weaponAimSpeed = 1.0f;

	public int id = 0;

	public Rigidbody ThisRigidpody; 

	public GameObject DamageHitLabel;
    public GameObject cannonBall;

    public Animator _animatorMan;
    public Animator _animatorManRider;
    public GameObject PlaneSelect;

	public AudioClip soundAttack;
	public AudioClip soundCount;

    public StateUnit stateUnit = new StateUnit();
    public Vector3 moveToDest = Vector3.zero;

    public Vector3 destination;
	public float speed = 2;
    public float currentRotationSpeed = 2;
    public float rotationSpeed = 2;

    private GameObject moveCursorObject;
    protected List<string> building_ar = new List<string>() { NameUnit.building.ToString(), NameUnit.Ore.ToString(), NameUnit.Repository.ToString() };

    public void SetState(NameGames NameGame) {
         this.StateGames = NameGame;
    }

    protected virtual void Awake() {
		selectionBounds = ResourceManager.InvalidBounds;
		CalculateBounds ();

		//damageStyle.normal.background = ResourceManager.DamageTexture;
		damageStyle.normal.textColor = Color.green;
	}



	protected virtual void Start () {

	}
    public void SetSelectUnit(bool value)
    {
        this._selectShip = value;
    }
    public bool SelectShip
    {
        get { return this._selectShip; }
       // set { selectShip = value; }
    }
 

    protected virtual void playSound(SoundItem name)
    {
        var audioKol = GetComponent<AudioSource>();
        
        // cannonBall

        if (SoundItem.soundAttack == name)
        {
            
            audioKol.clip = UserInput.HUD_UserInput.sound_ar.Where(a => a.name == "Sword_0" + (int)Random.Range(0, 8)).FirstOrDefault();
            
        }
        if (SoundItem.soundDead == name)
        {
            audioKol.clip = UserInput.HUD_UserInput.sound_ar.Where(a => a.name == "Dead_0" + (int)Random.Range(0, 5)).FirstOrDefault();
        }
        if (SoundItem.soundArchery == name)
        {
            audioKol.clip = UserInput.HUD_UserInput.sound_ar.Where(a => a.name == "Archery_0" + (int)Random.Range(0, 3)).FirstOrDefault();
        }
        if (SoundItem.soundCount == name)
        {
            audioKol.clip = soundCount;
        }
        audioKol.Play();
    }
    protected virtual void Update () {

		currentWeaponChargeTime += Time.deltaTime;
		if (stateUnit.attack && !movingIntoPosition && !aiming) {

		}
        // Выход за границы. Провал сквозь текстуры. Уничтожаем.
        if (transform.position.y<-10) {
           hitPoints = 0;
        }

		// смерть.
		if (hitPoints <= 0) {

			ModelTacticFight.tacticLog += "\n уничтожен"+objectName;
            SetAnimation("gogo", 4, "gogo", 8);
            if (speed > 0)
            {
                playSound(SoundItem.soundDead);
            }
            speed = 0;
           currentRotationSpeed = 0;
            rotationSpeed = 0;
            stateUnit.attack = false;
            stateUnit.rotate = false;
       
            this.tag = RTS.tagObject.shipSink.ToString();
			ThisRigidpody.detectCollisions = false;
            
            Destroy(gameObject, 5);
			//Destroy (gameObject);
		}

		if (this._selectShip) {

            PlaneSelect.SetActive(true);
        } else {

            PlaneSelect.SetActive(false);

        }

	
	}


	protected virtual void OnGUI() {
		drawFlag (fiend);

		DrawSelection (this._selectShip);
	}
	

	public void SetSelection(bool selected, Rect playingArea) {

		currentlySelected = selected;

		if (selected) {
			this.playingArea = playingArea;
		}
	}

	public string[] GetActions() {
		return actions;
	}

	public virtual void MouseClickSetCursor(GameObject hitObject, Vector3 hitPoint, Player controller) {
		
		//only handle input if currently selected


        // не земля
		if (hitObject &&  ! ResourceManager.Ground.Contains(hitObject.name)) {
			WorldObjectUnit worldObject = hitObject.transform.root.GetComponent< WorldObjectUnit > ();
	
			//clicked on another selectable object
			if (worldObject) {
	
				// У всех надо убрать выделение.
	
			}
            // Если это здание. null
			if (worldObject!=null) {
			    BeginAttack (worldObject, worldObject.fiend);
		     }
		} else {
			// Мы кликнули по земле.
			setCursorMoveReal(hitPoint);
			destination = hitPoint;
		}
	}

    /// <summary>
    /// Поставить курсор 3Д.
    /// </summary>
    /// <param name="destination"></param>
    public void setCursorMoveReal(Vector3 destination)
    {
        
        if (this._selectShip)
        {
            // Повторно ставит курсор в разных местах - удаляем артефакты.
            if (moveCursorObject != null)
            {
                Destroy(moveCursorObject);
            }
            moveCursorObject = Instantiate(UserInput.HUD_UserInput.moveCursor);
            UserInput.HUD_UserInput.moveCursor.transform.position = destination;
        }
    }

    public void BeginAttack(WorldObjectUnit target,bool ffiend) {
		this.target = target;
		if (TargetInRange ()) {
            // Дотягиваемся до цели?
            stateUnit.attack = true;
            stateUnit.move = false;
            stateUnit.rotate = false;
            PerformAttack ();
		} else {

            // Если враг, то отрегулировать позицию.
            if (ffiend)
            {
                AdjustPosition();
            }
            else {
                //AdjustPosition();
            }
		}
	}

	protected bool TargetInRange() {
		if (target == null) {
			return false;
		}
        var k = Vector3.Distance(transform.position, target.transform.position);
        // Растояние активации. Важно для интеллекта атаки игрока. Что-бы при приближение мог атаковать.
        if (Vector3.Distance(transform.position, target.transform.position) < 50&& Vector3.Distance(transform.position, target.transform.position) > weaponRange)
        {
            // Цель вне диапозона.
            AdjustPosition();
        }

        if (Vector3.Distance (transform.position, target.transform.position) < weaponRange) {
			return true;
		}

		return false;
	}

	private void AdjustPosition() {

		Unit self = this as Unit;


			movingIntoPosition = true;
			Vector3 attackPosition = FindNearestAttackPosition ();
	
        StartMove(attackPosition);
        stateUnit.attack = true;
        stateUnit.move = false;
        stateUnit.rotate = false;
        if (!self)
        {
            stateUnit.attack = false;
        }

    }
    public void StartMove(Vector3 destinationS)
    {
        if (!building_ar.Contains(objectName))
        {
            destination = destinationS;
            stateUnit.rotate = true;
            moveToDest = destination;
        }
    }
    private Vector3 FindNearestAttackPosition() {
        // цель не обнаружена
        if (target==null) {
            return new Vector3();
        }
        

        Vector3 direction = target.transform.position - transform.position;
        //float targetDistance = direction.magnitude;
        // Было 0.9f
        float distanceToTravel = direction.magnitude - (0.3f * weaponRange);

var kkk = objectName;
        var zzz = Vector3.Lerp(transform.position, target.transform.position, distanceToTravel / direction.magnitude);


        return Vector3.Lerp(transform.position, target.transform.position, distanceToTravel / direction.magnitude);
	}

	protected void PerformAttack() {
		if(!target) {
            stateUnit.attack = false;
			return;
		}
        if (!TargetInRange())
        {
            AdjustPosition();
        }
        else if (!TargetInFrontOfWeapon())
        {
            // Доворот на цель.
            AimAtTarget();

        }
        else if (ReadyToFire()) {
            // Использовать оружие.
            UseWeapon();
        }
	}
    /// <summary>
    /// Проверка с игнорированием, оси У, так как воюем в одной плоскоти.
    /// </summary>
    /// <returns></returns>
	protected bool TargetInFrontOfWeapon() {
        //Vector3 targetLocation = target.transform.position;
        //Vector3 direction = targetLocation - transform.position;
        Vector3 targetLocation = new Vector3(target.transform.position.x,0, target.transform.position.z);
        Vector3 direction = targetLocation - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);

        if (direction.normalized == transform.forward.normalized) { return true; }
        else { return false; }
	}

	protected virtual void AimAtTarget() {
		aiming = true;
		//this behaviour needs to be specified by a specific object
	}
    /// <summary>
    /// Возвращает какой группировке принадлежит юнит (свой-чужой). Если false, значит свой.
    /// </summary>
    /// <param name="armRange"></param>
    /// <returns></returns>
    protected bool? RayCastUnit(float armRange, bool? left=null) {

        Vector3 trend = Vector3.forward;

        if (left == false) {
            trend = Vector3.left;
        }

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.TransformDirection(trend));

        

        // Стоит ли свой юнит на пути? Бросаем луч.
        if (Physics.Raycast(ray, out hit, armRange))
        {
            if (hit.collider != null)
            {
                var unitShip = hit.collider.GetComponent<Unit>();
                if (unitShip != null)
                {
                    //permissionAttack = unitShip.fiend != fiend;
                    return unitShip.fiend != fiend;
                }
                //print(permissionAttack+" @@@There is something  " + hit.collider.name+" ZZZ "+ unitShip.fiend);

            }

        }
        return null;
    }
	protected virtual void UseWeapon() {



        // Это лучник.
        if (objectName == NameUnit.crossbow.ToString())
        {
            ////

            bool permissionAttack = false;
            /*
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            // Стоит ли свой юнит на пути? Бросаем луч.
            if (Physics.Raycast(ray, out hit, weaponRange))
            {
                if (hit.collider != null)
                {
                    var unitShip = hit.collider.GetComponent<Unit>();
                    if (unitShip != null)
                    {
                        permissionAttack = unitShip.fiend != fiend;
                    }
                    //print(permissionAttack+" @@@There is something  " + hit.collider.name+" ZZZ "+ unitShip.fiend);

                }

            }
            */
            var shipKick = RayCastUnit(weaponRange);
            if (shipKick != null) {
                //
                permissionAttack = (bool)shipKick;
            }


            // Можно атаковать, никто не стоит на пути.
            if (permissionAttack)
            {
                
              
                ////
                GameObject k = Instantiate(cannonBall);

                k.transform.position = new Vector3(this.transform.position.x + 3, this.transform.position.y + 1, this.transform.position.z);
                var rb = k.GetComponent<Rigidbody>();
                rb.velocity = transform.TransformDirection(new Vector3(0, 0, 35));
            }
            else
            {
                return;
            }

            playSound(SoundItem.soundArchery);
        }
        else {
            // Стандартная атака.
            playSound(SoundItem.soundAttack);
            if (objectName == NameUnit.labor.ToString())
            {
                if (target.objectName == NameUnit.Ore.ToString())
                {
                    Stock++;
                    if (fiend) {
                        //GlobalConf.Money[1] += 1;
                    }
                    else {
                        //GlobalConf.Money[0] += 1;
                    }

                }
                if (target.objectName == NameUnit.Repository.ToString()) {
                    if (fiend)
                    {
                        GlobalConf.Money[1] += Stock;
                    }
                    else
                    {
                        GlobalConf.Money[0] += Stock;
                    }
                    Stock = 0;
                    //stateUnit.rotate = true;
                    //stateUnit.move = true;
                }

            }
        }
        // Стандартная атака.
        SetAnimation("gogo", 3, "gogo", 7);

            currentWeaponChargeTime = 0.0f;
            //	
            target.HitShipIsTarget(weaponDamage);
    }
    /// <summary>
    /// Попадание в корабль. 
    /// </summary>
    public void HitShipIsTarget(int damage) {

        this.hitPoints -= damage;

        //target.muzzleFlashHitLifeTime=muzzleFlashHitMax;
        //target.muzzleFlashHit.active = true;

        Instantiate (DamageHitLabel);
		DamageHitLabel.transform.position  = transform.position;
		DamageHit damageLabel = DamageHitLabel.GetComponent<DamageHit> ();
		damageLabel._damageLabel = damage.ToString();
	}

	private void ChangeSelection(WorldObjectUnit worldObject, UserInput controller) {
		//this should be called by the following line, but there is an outside chance it will not
		SetSelection(false, playingArea);
		if (controller.WorldObjectSelectedClass) {
			controller.WorldObjectSelectedClass.SetSelection (false, playingArea);
		}
		controller.WorldObjectSelectedClass = worldObject;
		worldObject.SetSelection(true, UserInput.GetPlayingArea());
	}

	// Рисование квадрата, вокруг выбранного объекта.
	private void DrawSelection(bool showSelect) {

		GUI.skin = ResourceManager.SelectBoxSkin;

		playingArea = UserInput.GetPlayingArea ();

		Rect selectBox = WorkManager.CalculateSelectionBox(selectionBounds, playingArea);

		//Draw the selection box around the currently selected object, within the bounds of the playing area
		GUI.BeginGroup(playingArea);
		if (showSelect) {
			DrawSelectionBox (selectBox);

		}

		DrawHealthBar(selectBox, objectName);
	
		GUI.EndGroup();

	}
	// рендеринг квадрата вокруг юнита?
	public void CalculateBounds() {
		selectionBounds = new Bounds(transform.position, Vector3.zero);
		foreach(Renderer r in GetComponentsInChildren< Renderer >()) {
			selectionBounds.Encapsulate(r.bounds);
		}
	}




	protected bool ReadyToFire() {
		if(currentWeaponChargeTime >= weaponRechargeTime) return true;
		return false;
	}


	protected virtual void DrawSelectionBox(Rect selectBox) {
		GUI.Box(selectBox, "");
		CalculateCurrentHealth();
	    GUI.Label(new Rect(selectBox.x, selectBox.y - 7, selectBox.width * healthPercentage, 5), "", healthStyle);
	}

	protected virtual void CalculateCurrentHealth() {
		healthPercentage = (float)hitPoints / (float)maxHitPoints;
		if(healthPercentage > 0.65f) healthStyle.normal.background = ResourceManager.HealthyTexture;
		else if(healthPercentage > 0.35f) healthStyle.normal.background = ResourceManager.DamagedTexture;
		else healthStyle.normal.background = ResourceManager.CriticalTexture;
	}

	public virtual void SetHoverState(GameObject hoverObject) {
		//only handle input if owned by a human player and currently selected
		if(currentlySelected) {
            //
            if (!ResourceManager.Ground.Contains(hoverObject.name))
            { player.UserInputPlayer.SetCursorState(CursorState.Select); }
		}
	}
	/// <summary>
	/// Здоровье
	/// </summary>
	/// <param name="selectBox">Select box.</param>
	/// <param name="label">Label.</param>
	protected void DrawHealthBar(Rect selectBox, string label) {

		healthStyle.padding.top = -20;
		healthStyle.fontStyle = FontStyle.Bold;
		GUI.Label(new Rect(selectBox.x, selectBox.y - 7, selectBox.width * healthPercentage, 5), label, healthStyle);
	}

	/// <summary>
	/// Нарисовать флаг над кораблем.
	/// </summary>
	/// <param name="selectBox">Select box.</param>
	/// <param name="inFiend">If set to <c>true</c> in fiend.</param>
	public void drawFlag(bool inFiend) {
		Rect selectBox = WorkManager.CalculateSelectionBox(selectionBounds, playingArea);


		//int idFlag = 1;
        string nameFlag = ImageDuty.shield_4.ToString();
		if (inFiend == true) {
            // Это враг.
			//idFlag = 0;
            nameFlag = GlobalConf.FiendOne.flag;

        }
		GUI.BeginGroup(playingArea);

       
        if (UserInput.HUD_UserInput!=null)
        {
            
            GUI.DrawTexture(new Rect(selectBox.x, selectBox.y - 45, 15, 15), UserInput.HUD_UserInput.flagTexture.Where(a => a.name == nameFlag).FirstOrDefault());
        }
        GUI.EndGroup();
	}

	private bool permissionMakeMove() {
		
		if (ResourceManager.InvalidPosition != destination) {
			
			//return false;
		}
		if (Vector3.Distance (transform.position, destination) > stopDistanceOffset) {
			return true;
		}

		return false;
	}
	public void MakeMove() {
        // Поправка, если включается другие режимы, что-бы не было этого.
        if (stateUnit.move)
        {
            stateUnit.rotate = false;
            stateUnit.attack = false;
        }
		// Движение?
		transform.GetComponent<Rigidbody>().velocity = transform.forward * speed;


		if (!fiend) {
            // Игрок.
			//print (moving+" MOVE "+Vector3.Distance (transform.position, destination)+" < "+stopDistanceOffset+"   obj "+transform.position+" dest "+destination);
			// Остановить приближение к цкли.
			if (Vector3.Distance (transform.position, destination) < stopDistanceOffset) {
				zeroMove ();
			}
			//print (Vector3.Distance (transform.position, destination)+"=="+stopDistanceOffset+"===="+(Vector3.Distance (transform.position, destination) < stopDistanceOffset));
			if (transform.position == destination) {
				zeroMove ();
			}
		} else {
            // Враг.
			if (TargetInRange ()) {
				zeroMove ();
			}
		}
		// stop move.
		if (!stateUnit.move) {
			
			if (!fiend) {
                SetAnimation("gogo", 1, "gogo", 5);

                //print (_animatorMan.GetInteger("gogo")+" STOP MOVE 1___ ==" +objectName);
            }
		} else {
            SetAnimation("gogo", 2, "gogo", 6);

		}

	}
    private void SetAnimation(string position,int number, string positionHorse,int numberHorse)
    {
        if (!building_ar.Contains(objectName))
        {
            _animatorMan.SetInteger(position, number);
            if (objectName == NameUnit.horse.ToString())
            {
                _animatorManRider.SetInteger(positionHorse, numberHorse);
            }
        }
    }


    private void zeroMove()
	{
        stateUnit.move = false;
		movingIntoPosition = false;

		transform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}
	
 
    
}
public class StateUnit {
public bool move { get; set; }
    public bool rotate { get; set; }
    public bool attack { get; set; }
}