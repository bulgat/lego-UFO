using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;


public class Unit : WorldObjectUnit {
	
	private Quaternion targetRotation;

	private Quaternion aimRotation;



	public List<NewUnit> unit_Ship = new List<NewUnit>();

    public GameObject hair;
    public GameObject helmet;
    public GameObject helmetCrossBow;
    public GameObject shield;
    public GameObject sword;
public GameObject longSword;
    public GameObject pike;
    public GameObject crossbow;
    public GameObject pikeTool;

    public GameObject hairHorse;

    public Vector3 positionStart;

    public GameObject wagon;
    public GameObject ore;

    private int numAttackFiend;
    //private string nameAttackFiend;
    private WorldObjectUnit WorldObjectAttackFiend;
    private int LengthAttackFiend;
    public string tagStart;
    
    protected virtual void Start()
    {
        base.Start();
        if (!building_ar.Contains(objectName)) { 

            if (_animatorMan != null)
            {
                _animatorMan.SetInteger("gogo", 1);
            }
            
            if (objectName == NameUnit.horse.ToString())
            {
                if (_animatorManRider != null)
                {
                    _animatorManRider.SetInteger("gogo", 5);
                }
            }

            destroyElement(objectName);
        }
        
        if(objectName== NameUnit.labor.ToString())
        {
            stateUnit.rotate = true;
        }
        if (objectName == NameUnit.Ore.ToString())
        {
            positionStart.y += 5;
            destroyElement(objectName);
        }
        else {
           // positionStart.y += 5;
        }
        if (objectName == NameUnit.Repository.ToString())
        {
            positionStart.y += 5;
            positionStart.z = -2;
            destroyElement(objectName);
        }
        transform.position = positionStart;

        tagStart = "";
        if (tagStart != null)
        {
            
            tag = tagStart;
        }
        //Debug.Log(positionStart+"========Hit Something " +  objectName+"   f="+ tag);
    }

    public void destroyElement(string name) {

        if (name == NameUnit.Ore.ToString())
        {
            Destroy(wagon);
        }
        if (name == NameUnit.Repository.ToString())
        {
            Destroy(ore);
        }
        if (name == NameUnit.pikeman.ToString())
        {
            Destroy(helmet);
            Destroy(shield);
            Destroy(sword);
            Destroy(crossbow);
            Destroy(helmetCrossBow);
            Destroy(pikeTool);
Destroy(longSword);
        }
        if (name == NameUnit.labor.ToString())
        {
            Destroy(helmet);
            Destroy(shield);
            Destroy(sword);
            Destroy(crossbow);
            Destroy(pike);
            Destroy(helmetCrossBow);
		Destroy(longSword);
        }
        if (name == NameUnit.sword.ToString())
        {
            Destroy(hair);
            Destroy(pike);
            Destroy(crossbow);
            Destroy(helmetCrossBow);
            Destroy(pikeTool);
Destroy(longSword);
        }
        if (name == NameUnit.crossbow.ToString())
        {
            Destroy(hair);
            Destroy(helmet);
            Destroy(shield);
            Destroy(sword);
            Destroy(pike);
            Destroy(pikeTool);
Destroy(longSword);
        }
if (name == NameUnit.longSword.ToString())
        {
Destroy(hair);
		//Destroy(helmet);
            Destroy(shield);
            Destroy(sword);
            Destroy(crossbow);
            Destroy(helmetCrossBow);
            Destroy(pikeTool);
Destroy(pike);
}
        if (name == NameUnit.horse.ToString())
        {
            Destroy(hairHorse);
            // DestroyImmediate(hair);
        }
    }

    // Метод вызываемый при столкновении объекта
    void OnCollisionEnter(Collision myCollision) {
         // Передаем сообщение в консоль Unity  
        if (myCollision.transform.tag != "Sbutton")
        {

            //WorldObjectAttackFiend = AiShip(fiend);
           // stateUnit.move = false;
            ChangeBehavior();
        }

	}
    private void ChangeBehavior() {
        
        WorldObjectAttackFiend = AiShip(fiend);
        stateUnit.move = false;
    }


	// Двигаться через 5 секунд, после столкновения StartCoroutine (Delay ()). 
	private IEnumerator Delay () {
		yield return new WaitForSeconds (detourDelayTime);

        detourDelay = false;
        //secDelay++;

    }
    bool detourDelay = false;
    int detourDelayTime = 1;


    protected override void Update () {

        base.Update();
        ///
        var shipKick = RayCastUnit(5);
        if (shipKick != null)
        {
            // Свой юнит стоит передо мной.
            if ((bool)shipKick==false)
            {
                int detour = 5;
                var shipLeft = RayCastUnit(detour, false);
                if (shipLeft==null) {
                    if (!detourDelay)
                    {
                        Debug.Log("НЕ МЕШАЙ!  Hit Something ");
                        moveToDest = new Vector3(transform.position.x, transform.position.y, transform.position.z + detour);
                        detourDelay = true;
                        detourDelayTime = (int)Random.Range(1, 5);
                        Delay();
                    }
                }

                ChangeBehavior();
            }
        }
        ///

        // Если это здание, для него ничего не надо.
        if (!building_ar.Contains(objectName))
        {

            if (destination!=Vector3.zero) { 
                if (CourseToTarget())
                {
                     TurnToTarget();
                }  else
                {
                    stateUnit.rotate = false;
                }
                if (!TargetInRange())
                {
                    stateUnit.attack = false;
                }
                else {
                    // Цель в диапозоне атаки, надо атаковать?
                    if (!building_ar.Contains(objectName))
                    {
                        if (!CourseToTarget()) {
                            if (ReadyToFire())
                            {
                                // Использовать оружие.
                                UseWeapon();
                            }
                        }
                       
                    }
                }
                if (!stateUnit.rotate&& !stateUnit.attack) {
                    stateUnit.move = true;
                }
            }
          
            if (stateUnit.move)
            {
                MakeMove();
            }
            else
            {
                // Прекратить движение!
                transform.GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
           
        }
		if (hitPoints <= 0) {
			ModelTacticFight.deleteSelectIdShip (idFleet,id);

		}

		// Ответственный за выбор множества юнитов прямоугольником.
		if (Input.GetMouseButton(0)) {


			Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
			camPos.y = UserInput.invertMouseY(camPos.y); 
           
            // Здесь юнит выделяется прямоугольником, но если он работает всегда, то один клик не выделит юнит.
            // Что делать?
            //selectShip = HUD.selectionRect.Contains(camPos);
        }

			//GameObject.material.color = Color.red;
            // если юнит враг.
		if (fiend) {
            // если целей нет.
			if (LengthAttackFiend != UserInput.getAllShip ("ship").Length) {
			
				WorldObjectAttackFiend = AiShip (fiend);
			} else {
				// цель преследуем.
				Chasing ();
			}
		} else {
            // Игрок.
            if (!stateUnit.move)
            {
                // Ответная атака?
                // Атака игроком блишайшей цели, без погони.
                WorldObjectAttackFiend = AiShip(fiend);
               BeginAttack(WorldObjectAttackFiend, fiend);
        
                //stateUnit.rotate = false;
                stateUnit.rotate = true;
                //stateUnit.move = true;
            }
           
		}

		NewUnit unit_one = getShipWith_ar ();
		if (unit_one != null) {
            // Зачем хиты передаются? а это глобальный наблюдатель! Передача в глобальную стратегию
            // Характеристик юнита.
			unit_one.hitPoints = hitPoints;
		}
		CalculateBounds();
        // Лвим еще одну ошибку - беда какаята, с двумя включающими режимима- код г..
        if (stateUnit.move&& stateUnit.attack)
        {
            //stateUnit.attack = false;
            //stateUnit.move = false;
        }
	}

   public bool GetRectSelect()
    {
        Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);
        camPos.y = UserInput.invertMouseY(camPos.y);
        return UserInput.selectionRect.Contains(camPos);
    }

    protected NewUnit getShipWith_ar() {
		foreach (InfoFleet fleet in GlobalConf.GetViewFleetList()) {
			foreach (NewUnit oneShip in fleet.ship_ar) {
				if (oneShip.uid==id) {
					//oneShip.hitPoints = hitPoints;
					return oneShip;
				}
			}
		}
		return null;
	}

	

	// Авто выбор цели.
	protected WorldObjectUnit AiShip(bool fiendIn) {

        GameObject[] ship_ar;
        bool noDifference = false;

        // Оптимизация, если игрок, возращаем нуль.
        if (objectName!= NameUnit.labor.ToString())
        {
            // Поиск боевых целей.
            ship_ar = UserInput.getAllShip("ship");
        }
        else
        {
            // Рабочий?.
            if (Stock <= 10)
            {
                ship_ar = UserInput.getAllShip(NameUnit.Ore.ToString());
            } else
            {
                // Переполнено хранилище юнита.
                stateUnit.attack = false;
                ship_ar = UserInput.getAllShip(NameUnit.Repository.ToString());
            }

            noDifference = true;
        }

        
		LengthAttackFiend = ship_ar.Length;

        // Вернется 0, если цели не найдены.
		int? numAttackFiendNull = AI_ship.getShip (transform.position,ship_ar,fiendIn, noDifference);
        if (numAttackFiendNull == null)
        {
            return null;
        }
        numAttackFiend = (int)numAttackFiendNull;


        //nameAttackFiend = ship_ar[numAttackFiend].GetComponent<Unit>().objectName;

        // Если враг.
		if (fiendIn) {
			destination = ship_ar [numAttackFiend].transform.position;
		}
		return ship_ar [numAttackFiend].GetComponent<WorldObjectUnit> ();
	}
	void Chasing ()
	{
		MakeMove ();
		BeginAttack(WorldObjectAttackFiend,true);
	}




	protected override void OnGUI() {
		base.OnGUI();
	}

	public override void SetHoverState(GameObject hoverObject) {
		base.SetHoverState(hoverObject);
		//only handle input if owned by a human player and currently selected
		if(currentlySelected) {
			if (ResourceManager.Ground.Contains(hoverObject.name)) {
				player.UserInputPlayer.SetCursorState (CursorState.Move);
			}
		}
	}

	public override void MouseClickSetCursor(GameObject hitObject, Vector3 hitPoint, Player controller) {


		// странно
		base.MouseClickSetCursor(hitObject, hitPoint, controller);


		
        Debug.Log(" SELECT== [" + this._selectShip + "] p  = "+ currentlySelected);

		//only handle input if owned by a human player and currently selected
		//player   player.human
		if(currentlySelected||this._selectShip) {

            

            if (ResourceManager.Ground.Contains(hitObject.name) && hitPoint != ResourceManager.InvalidPosition) {
                // Отмена атаки.
                stateUnit.attack = false;
                
                if (!fiend)
                {
                    destination = hitPoint;
                }
                
                // Поставить курсор 3Д.
                setCursorMoveReal(destination);
				StartMove(destination);
			}
		}
	}
    /// Правильный курс на цель?
    private bool CourseToTarget()
    {
        Vector3 direction = (moveToDest - transform.position).normalized;
        float angle = Vector3.Angle(direction, transform.forward);
        // Выясняем если угол входит в нужный передел, то прекращаем вращаться. 
        if (System.Math.Abs(Vector3.Dot(Vector3.Cross(transform.forward, direction), transform.up)) < 0.1f)
        {
            // Поворачивать не надо.
            return false;
        }
        // Поворачиваем.
        return true;
    }

    private void TurnToTarget() {


        
        Vector3 direction = (moveToDest - transform.position).normalized;


		float angle = Vector3.Angle(direction,transform.forward);


            var k = Vector3.Dot(Vector3.Cross(transform.forward, direction), transform.up);

            if (Vector3.Dot(Vector3.Cross(transform.forward,direction),transform.up)<0) {
				currentRotationSpeed = -rotationSpeed;
			} else {
				currentRotationSpeed =  rotationSpeed;
			}
            // Выясняем если угол входит в нужный передел, то прекращаем вращаться. 
            if (System.Math.Abs(Vector3.Dot(Vector3.Cross(transform.forward, direction), transform.up))<0.1f) {
                stateUnit.rotate = false;
                stateUnit.move = true;
            }


		if (angle>rotationSpeed) {
			transform.Rotate(new Vector3(0,currentRotationSpeed,0));
           
        } else {
			transform.LookAt(new Vector3(moveToDest.x,transform.position.y,moveToDest.z));

            stateUnit.rotate = false;
            stateUnit.move = true;
		
			ThisRigidpody.AddTorque(0,0,0);
		
		}

	}

    /// <summary>
    /// Странно. Здесь происходит поворот на цель. 
    /// </summary>
	protected override void AimAtTarget () {
		base.AimAtTarget();

        //Проверка с игнорированием, оси У, так как воюем в одной плоскоти.
        aimRotation = Quaternion.LookRotation(new Vector3(target.transform.position.x,0, target.transform.position.z) - new Vector3( transform.position.x,0, transform.position.z));
        AimAtTargetRotate();
    }
    private void AimAtTargetRotate() {
        if (aiming)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, aimRotation, weaponAimSpeed);

            CalculateBounds();
            //sometimes it gets stuck exactly 180 degrees out in the calculation and does nothing, this check fixes that
            Quaternion inverseAimRotation = new Quaternion(-aimRotation.x, -aimRotation.y, -aimRotation.z, -aimRotation.w);

            if (transform.rotation == aimRotation || transform.rotation == inverseAimRotation)
            {
                aiming = false;
            }
        }
    }

}
