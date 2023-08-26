using UnityEngine;
using System.Collections;
using RTS;
using System.Collections.Generic;
using SimpleJSON;
using Assets.Global;

public class UserInput : MonoBehaviour {
	
	private Player player;
	private bool blockScrollLever;
    public static WorldObjectUnit SelectUnitMouse;
    public GUISkin selectBoxSkin;
    public Texture2D healthy, damaged, critical;
    public Texture2D damage;

    // Use this for initialization
    void Start () {
		player = transform.root.GetComponent< Player >();
		EventListeren.eventListerenController += blockScroll;
		EventListeren.eventListerenController += unBlockScroll;
        EventListeren.eventListerenController += CameraSetUpBattle;

        // Выставляем камеру, что-бы было красиво игроку.
        Camera.main.transform.eulerAngles = new Vector3(24,-1,0);
        Camera.main.transform.transform.position = new Vector3(5,10,-9);


        SetCursorState(CursorState.Select);
        //player = transform.root.GetComponent<Player>();

        if (HUD_UserInput == null)
        {
            HUD_UserInput = this;
        }
        ResourceManager.StoreSelectBoxItems(selectBoxSkin, healthy, damaged, critical, damage);
    }

	private void blockScroll (string isPower, string no) {
		if (isPower == CommandState.BlockScroll.ToString ()) {

			blockScrollLever = true;
		}
	}
	private void unBlockScroll (string isPower, string no) {
		if (isPower == CommandState.unBlockScroll.ToString ()) {

			blockScrollLever=false;
		}
	}
    /// <summary>
    /// Ставим камеру в положение для битвы.
    /// </summary>
    /// <param name="isPower"></param>
    /// <param name="no"></param>
    private void CameraSetUpBattle(string isPower, string obj)
    {
        if (isPower == CommandState.CameraSetUpBattle.ToString())
        {
            var ar = JSONNode.Parse(obj);

            var positionOne = JsonUtility.FromJson<TypeUnitSend>(ar[CommandSend.fleetOne.ToString()]);
            var rotationOne = JsonUtility.FromJson<TypeUnitSend>(ar[CommandSend.fleetTwo.ToString()]);
			try
			{
				Camera.main.transform.position = new Vector3(positionOne.unitArray[0], positionOne.unitArray[1], positionOne.unitArray[2]);
				Camera.main.transform.eulerAngles = new Vector3(rotationOne.unitArray[0], rotationOne.unitArray[1], rotationOne.unitArray[2]);
			}
			catch
			{
				Debug.LogWarning("Camera Error");
			}
        }
    }


    // Update is called once per frame
    void Update () {
			MoveCamera();
			RotateCamera(); 
			MouseActivity();

        //////

    
        var ship_ar = getAllShip("ship");
        //print("00000==Объект выделен   L = " + ship_ar.Length);
        foreach (var ship in ship_ar)
        {
            var worldObject = ship.GetComponent<Unit>();
            if (worldObject.GetRectSelect() == true)
            {

                worldObject.SetSelectUnit( true);
            }
        }
        //print("==Объект выделен   ttt = " + ttt);
        Cleanup();
    }

    private void MoveCamera() {
		float xpos = Input.mousePosition.x;
		float ypos = Input.mousePosition.y;
		Vector3 movement = new Vector3(0,0,0);


		bool mouseScroll = false;

		if (!blockScrollLever) {
            // Блокировка от типа карты.
            
            // Тактическая карта.
            Vector2 blockScreen_x= GlobalConf.BlockScreenScroll_ar[0].Position_x;
            Vector2 blockScreen_z= GlobalConf.BlockScreenScroll_ar[0].Position_z;
            if (!Player._goBattle)
            {
                // Глобальная карта
                blockScreen_x = GlobalConf.BlockScreenScroll_ar[1].Position_x;
                blockScreen_z = GlobalConf.BlockScreenScroll_ar[1].Position_z;
            }
            if (GlobalConf.ModeStickBattle) {
                // Stick Battle
                blockScreen_x = GlobalConf.BlockScreenScroll_ar[2].Position_x;
                blockScreen_z = GlobalConf.BlockScreenScroll_ar[2].Position_z;
                ;
                //Camera.main.transform.eulerAngles = GlobalConf.StickBattleRotateCamera;
            }


				/////////
				if (Input.GetKey(KeyCode.D)){
					//Debug.Log("==========WWWWWWWWWWWW pressed.===============");
					movement.x += ResourceManager.ScrollSpeed;
				}
				if (Input.GetKey(KeyCode.A)){
					//Debug.Log("==========WWWWWWWWWWWW pressed.===============");
					movement.x -= ResourceManager.ScrollSpeed;
				}
				if (Input.GetKey(KeyCode.W)){
					//Debug.Log("==========WWWWWWWWWWWW pressed.===============");
					movement.z += ResourceManager.ScrollSpeed;
				}
				if (Input.GetKey(KeyCode.S)){
					//Debug.Log("==========WWWWWWWWWWWW pressed.===============");
					movement.z -= ResourceManager.ScrollSpeed;
				}
			///////
			try { 
			//horizontal camera movement
			if (xpos >= 0 && xpos < ResourceManager.ScrollWidth&&Camera.main.transform.position.x>blockScreen_x.x) {

                if (GlobalConf.ModeStickBattle) { Camera.main.transform.eulerAngles = StickBattle.StickBattleRotateCamera; }
                
                // Движение камеры влево
				movement.x -= ResourceManager.ScrollSpeed;
				SetCursorState (CursorState.PanLeft);
				mouseScroll = true;
			} else if (CameraScrollRight(xpos, blockScreen_x)) {
                if (GlobalConf.ModeStickBattle) 
				{ Camera.main.transform.eulerAngles = StickBattle.StickBattleRotateCamera; }

                // Движение камеры вправо
                movement.x += ResourceManager.ScrollSpeed;
				SetCursorState (CursorState.PanRight);
				mouseScroll = true;

				
			}
} catch {
                Debug.LogWarning("horizontal camera movement");
            }
			try {
			//vertical camera movement
			if (ypos >= 0 && ypos < ResourceManager.ScrollWidth&&Camera.main.transform.position.z>blockScreen_z.x) {
				movement.z -= ResourceManager.ScrollSpeed;
				SetCursorState (CursorState.PanDown);
				mouseScroll = true;
			} else if (ypos <= Screen.height && ypos > Screen.height - ResourceManager.ScrollWidth-40&&Camera.main.transform.position.z<blockScreen_z.y) {
				movement.z += ResourceManager.ScrollSpeed;
				SetCursorState (CursorState.PanUp);
				mouseScroll = true;

			}
            }
            catch {
				Debug.LogWarning("vertical camera movement");
			}
        }
	
		
		//make sure movement is in the direction the camera is pointing
		//but ignore the vertical tilt of the camera to get sensible scrolling
		movement = Camera.main.transform.TransformDirection(movement);
		movement.y = 0;
		
		//away from ground movement
		movement.y -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");
		
		//calculate desired camera position based on received input
		Vector3 origin = Camera.main.transform.position;
		Vector3 destination = origin;
		destination.x += movement.x;
		destination.y += movement.y;
		destination.z += movement.z;
		
		//limit away from ground movement to be between a minimum and maximum distance
		if(destination.y > ResourceManager.MaxCameraHeight) {
			destination.y = ResourceManager.MaxCameraHeight;
		} else if(destination.y < ResourceManager.MinCameraHeight) {
			destination.y = ResourceManager.MinCameraHeight;
		}
		
		//if a change in position is detected perform the necessary update
		if(destination != origin) {
			Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed);
		}


		if(!mouseScroll) {
			//try
			//{
				SetCursorState(CursorState.Select);
			//}
			//catch
			//{
			//	Debug.LogWarning("mouseScroll");
			//}
		}

	}
    private CursorState activeCursorState;
    public Texture2D activeCursor;
    public Texture2D selectCursor, leftCursor, rightCursor, upCursor, downCursor;
    private int currentFrame = 0;
    public Texture2D[] moveCursors, attackCursors, harvestCursors;
    public GUISkin mouseCursorSkin;
    static public string selectionName = "#_";
    private Vector3 startClick = -Vector3.one;
    static public Rect selectionRect = new Rect(0, 0, 0, 0);
    public Texture2D selectionHightLight = null;
    static public string selectionImage = "";
    static public string hitPoints = "#_";
    public static UserInput HUD_UserInput;
    public Sprite[] imageMessage_ar;
    public Sprite[] imageTypeUnit_ar;
    public GameObject moveCursor;
    public Sprite[] imageBigBack_ar;
    public AudioClip[] sound_ar;
    public Sprite[] imageDuty_ar;
    public Texture2D[] flagTexture;
    public WorldObjectUnit WorldObjectSelectedClass { get; set; }
    public void SetCursorState(CursorState newState)
    {
        activeCursorState = newState;


        if (player)
        {
            if (WorldObjectSelectedClass)
            {
                newState = CursorState.Attack;
            }
        }
        //Debug.Log(newState+"## "+attackCursors.Length);

        switch (newState)
        {
            case CursorState.Select:
                //activeCursor = selectCursor;
                if (activeCursor == leftCursor || activeCursor == rightCursor || activeCursor == upCursor || activeCursor == downCursor)
                {
                    activeCursor = selectCursor;
                }
                break;
            case CursorState.Attack:
                currentFrame = (int)Time.time % attackCursors.Length;

                activeCursor = attackCursors[currentFrame];
                //activeCursor = attackCursors;
                break;
            case CursorState.Harvest:
                currentFrame = (int)Time.time % harvestCursors.Length;
                activeCursor = harvestCursors[currentFrame];
                break;
            case CursorState.Move:
                currentFrame = (int)Time.time % moveCursors.Length;
                activeCursor = moveCursors[currentFrame];
                break;
            case CursorState.PanLeft:
                activeCursor = leftCursor;
                break;
            case CursorState.PanRight:
                activeCursor = rightCursor;
                break;
            case CursorState.PanUp:
                activeCursor = upCursor;
                break;
            case CursorState.PanDown:
                activeCursor = downCursor;
                break;
            default: break;
        }
    }
    private void DrawMouseCursor()
    {
        bool mouseOverHud = !MouseInBounds() && activeCursorState != CursorState.PanRight && activeCursorState != CursorState.PanUp;



        if (!MouseInBounds())
        {
            if (mouseOverHud)
                Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
            GUI.skin = mouseCursorSkin;
            GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
            UpdateCursorAnimation();
            Rect cursorPosition = GetCursorDrawPosition();
            GUI.Label(cursorPosition, activeCursor);
            GUI.EndGroup();
        }
    }
    public bool MouseInBounds()
    {
        //Screen coordinates start in the lower-left corner of the screen
        //not the top-left of the screen like the drawing coordinates do
        Vector3 mousePos = Input.mousePosition;
        bool insideWidth = mousePos.x >= 0 && mousePos.x <= Screen.width - ResourceManager.ORDERS_BAR_WIDTH;
        bool insideHeight = mousePos.y >= 0 && mousePos.y <= Screen.height - ResourceManager.RESOURCE_BAR_HEIGHT;

        return insideWidth && insideHeight;
    }




    private void UpdateCursorAnimation()
    {
        //sequence animation for cursor (based on more than one image for the cursor)
        //change once per second, loops through array of images
        if (activeCursorState == CursorState.Move)
        {
            currentFrame = (int)Time.time % moveCursors.Length;
            activeCursor = moveCursors[currentFrame];
        }
        else if (activeCursorState == CursorState.Attack)
        {
            currentFrame = (int)Time.time % attackCursors.Length;
            activeCursor = attackCursors[currentFrame];
        }
        else if (activeCursorState == CursorState.Harvest)
        {
            currentFrame = (int)Time.time % harvestCursors.Length;
            activeCursor = harvestCursors[currentFrame];
        }
    }
    private Rect GetCursorDrawPosition()
    {
        //set base position for custom cursor image
        float leftPos = Input.mousePosition.x;
        float topPos = Screen.height - Input.mousePosition.y; //screen draw coordinates are inverted
        if (activeCursor==null)
        {
            return new Rect(leftPos, topPos, 10, 10);
        } 
        //adjust position base on the type of cursor being shown
        if (activeCursorState == CursorState.PanRight) leftPos = Screen.width - activeCursor.width;
        else if (activeCursorState == CursorState.PanDown) topPos = Screen.height - activeCursor.height;
        else if (activeCursorState == CursorState.Move || activeCursorState == CursorState.Select || activeCursorState == CursorState.Harvest)
        {
            if (activeCursor)
            {
                topPos -= activeCursor.height / 2;
                leftPos -= activeCursor.width / 2;
            }
        }
       
        return new Rect(leftPos, topPos, activeCursor.width, activeCursor.height);
    }
    private bool CameraScrollRight(float xpos, Vector2 blockScreen_x)
    {
        var RightPanel = new Vector2(155,185);
        if (GlobalConf.ModeStickBattle) {
            RightPanel = new Vector2(0, 20);
        }
        // xpos <= Screen.width && xpos > Screen.width - 175 && Camera.main.transform.position.x < GlobalConf.blockScreenScroll_x.y
        if (Camera.main.transform.position.x < blockScreen_x.y) {
            if (xpos <= Screen.width - RightPanel.x && xpos > Screen.width - RightPanel.y) {
                return true;
            }
  
        }
    
        return false;
    }
    // Update is called once per frame
    void OnGUI()
    {

        if (ResourceManager.tacticMap)
        {
            DrawOrdersBar();
           
            DrawMouseCursor();

            if (startClick != -Vector3.one)
            {
                GUI.color = new Color(1, 1, 1, 0.5f);

                GUI.DrawTexture(selectionRect, selectionHightLight);
              
            }

        }


    }

    // battle interface
    private void DrawOrdersBar()
    {


        if (UserInput.SelectUnitMouse != null)
        {
            selectionName = UserInput.SelectUnitMouse.objectName;
            hitPoints = UserInput.SelectUnitMouse.hitPoints.ToString();
            if (selectionName == NameUnit.pikeman.ToString())
            {
                selectionImage = ImageBible.peasant.ToString();
            }
            if (selectionName == NameUnit.crossbow.ToString())
            {
                selectionImage = ImageBible.crossbow.ToString();
            }
            if (selectionName == NameUnit.horse.ToString())
            {
                selectionImage = ImageBible.knight.ToString();
            }
            if (selectionName == NameUnit.sword.ToString())
            {
                selectionImage = ImageBible.sword.ToString();
            }
            if (selectionName == NameUnit.longSword.ToString())
            {
                selectionImage = ImageBible.longSword.ToString();
            }
        }


    }

    private void RotateCamera() {
		Vector3 origin = Camera.main.transform.eulerAngles;
		Vector3 destination = origin;

		//detect rotation amount if ALT is being held and the Right mouse button is down
		//if((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetMouseButton(1)) {
		if(Input.GetKey ("down")||Input.GetMouseButton(1)) {

			destination.x -= Input.GetAxis("Mouse Y") * ResourceManager.RotateAmount;
			destination.y += Input.GetAxis("Mouse X") * ResourceManager.RotateAmount;
		}
		
		//if a change in position is detected perform the necessary update
		if(destination != origin) {
			Camera.main.transform.eulerAngles = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.RotateSpeed);
		}
	}

	private void MouseActivity() {
       
        if (Input.GetMouseButtonDown (0)) {
			
			LeftMouseClick ();
            return;
		}
        if (Input.GetMouseButtonDown (1)) {
			 Debug.Log(" MouseActivity =    RIGHT  Flag =");
			RightMouseClick ();
		}
	}

	// Надо собрать все выделенные объекты. И все послать в заданную точку.
	private List<WorldObjectUnit> getAllSelectShip(bool antiSelect) {
		// Надо собрать все выделенные объекты. И все послать в заданную точку.
		List<WorldObjectUnit> selectShip_ar = new List<WorldObjectUnit>();
		GameObject[] ship_ar =  getAllShip("ship");
		foreach (GameObject oneShip in ship_ar) {
			WorldObjectUnit UnitShip = oneShip.GetComponent<WorldObjectUnit>();
			if (!UnitShip.fiend) {
				if (UnitShip.SelectShip == antiSelect) {

					selectShip_ar.Add (UnitShip);
				}
			}

		}

		return selectShip_ar;
	}

	private void LeftMouseClick() {

		//print ("%%%=================LeftMouseClick AdjustPosition = ");
GameObject hitObject = FindHitObject();
		if(MouseInBounds()) {
			

			Vector3 hitPoint = FindHitPoint();
			if(hitObject && hitPoint != ResourceManager.InvalidPosition) {
                
                
                //bool blockUndoSelect = false;

                if (ResourceManager.Ground.Contains(hitObject.name))
                {
                    

                    // Надо собрать все выделенные объекты. И все послать в заданную точку.
                    // Мы выбираем не выбранные юниты, странно...
   
                    List<WorldObjectUnit> selectShip_ar = getAllSelectShip(true);

                    foreach (WorldObjectUnit selectShip in selectShip_ar)
                    {
                        // Повесить на юнит квадрат выделения.
                        selectShip.SetSelectUnit( true);

                        // Заодно назначает атаку на врага (если по нему тыкнули.)
                        selectShip.MouseClickSetCursor(hitObject, hitPoint, player);
                    }

                    print("==Объект выделен с помощью прямоугольника. Length = " + selectShip_ar.Count);
                    // Объект выделен с помощью прямоугольника.
  
                    //if (selectShip_ar.Count > 0)
                    //{
                    //    blockUndoSelect = true;
                    //}
                }
                else
                {
                    // Имя объекта не содержит имя земли.
                    if (!ResourceManager.Ground.Contains(hitObject.name))
                    {
                        // Объект выделен тыком.
                        print(" 000000= Объект выделен тыком.." + hitObject.name);
      
                        // Значит это юнит?
                        WorldObjectUnit worldObject = hitObject.transform.root.GetComponent<WorldObjectUnit>();


                        // Это юнит!
                        if (worldObject)
                        {
                            print(worldObject + "= Объект выделен тыком.."+ worldObject.objectName);

                            //we already know the player has no selected object

                            // отображаем то что выделили.
                            SelectUnitMouse = worldObject;


                            // Это игрок
                            if (!worldObject.fiend)
                            {
                                // Пробежатся по всем объектам и отключить выделение.
                                UndoSelectShipAll();

                                worldObject.SetSelectUnit(true);
                                

                            }
                            // Здесь всем выделенным объектам - нужен приказ на атаку этого вражеского объекта.
                            // Это враг.
                            if (worldObject.fiend)
                            {
                                worldObject.SetSelectUnit( false);

                                List<WorldObjectUnit> selectShip_ar = getAllSelectShip(true);
                                foreach (WorldObjectUnit selectShip in selectShip_ar)
                                {

                                    // Заодно назначает атаку на врага (если по нему тыкнули.)
                                    selectShip.MouseClickSetCursor(hitObject, hitPoint, player);
                                }

                            }


                        }
                    }

                }
                //ClickMouseGround(blockUndoSelect, hitObject);
                //print(" SELECT=== RIGHT  MouseClick __ [" + player + "] currentlySelected" );
            
                ///////////

            }


		}
        ClickMouseGround(true, hitObject);

        GetPlayingArea ();
	}
    private void ClickMouseGround(bool blockUndoSelect, GameObject hitObject)
    {

        
        if (hitObject)
        {
            print("SELECT=== LeftMouseClick ["+hitObject.name+"]  blockUndoSelect = " + blockUndoSelect);

            if (!WorldObjectSelectedClass && ResourceManager.Ground.Contains(hitObject.name))
            {
                if (!blockUndoSelect)
                {
                    print("NOT SELECT");
                    //we already know the player has no selected object
                    // Пробежатся по всем объектам и отключить выделение.
                    UndoSelectShipAll();

                }
            }
        }
    }


    public static Rect GetPlayingArea()
    {

        return new Rect(0, ResourceManager.RESOURCE_BAR_HEIGHT, Screen.width - ResourceManager.ORDERS_BAR_WIDTH, Screen.height - ResourceManager.RESOURCE_BAR_HEIGHT);
    }
    /// <summary>
    /// Пробежатся по всем объектам и отключить выделение.
    /// </summary>
    private void UndoSelectShipAll() {
        GameObject[] ship_ar = getAllShip("ship");
        foreach (GameObject oneShip in ship_ar)
        {
            WorldObjectUnit UnitShip = oneShip.GetComponent<WorldObjectUnit>();
            UnitShip.SetSelectUnit(false);
        }
    }
  
    /// <summary>
    /// Пускаем луч поиска цели из камеры в тык.
    /// </summary>
    /// <returns>The hit object.</returns>
    private GameObject FindHitObject() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			return hit.collider.gameObject;
		}
		return null;
	}
	private Vector3 FindHitPoint() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) return hit.point;
		return ResourceManager.InvalidPosition;
	}
	/// <summary>
	/// Правая клавиша мыши клик.
	/// </summary>
	private void RightMouseClick() {
        
        try
        { 
		    if(MouseInBounds() && !Input.GetKey(KeyCode.LeftAlt) && WorldObjectSelectedClass) {
			    WorldObjectSelectedClass.SetSelection(false,GetPlayingArea());
			    WorldObjectSelectedClass = null;
	
			    SetCursorState(CursorState.Harvest);
		    }
        } catch {
			Debug.LogWarning("hud RightMouseClick");
		}
		GetPlayingArea ();

		GameObject hitObject = FindHitObject();
		Vector3 hitPoint = FindHitPoint();
        GameObject[] ship_ar = getAllShip ("ship");

        print ("=================RightMouseClick  Pos  = "+ ship_ar.Length);

		foreach(GameObject ship in ship_ar) {
			Unit unit = ship.GetComponent<Unit>();
			if (unit!=null) {
				if (unit.fiend == false) {
                    print(hitObject+" name = "+ hitObject .name+ "=========Righi CLICK start==========="+ hitPoint);
					// right клик?!!
					unit.MouseClickSetCursor(hitObject, hitPoint, player);
				}
			}
		} 
		//////
	}
    private void Cleanup()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {

            startClick = -Vector3.one;
        }
        if (Input.GetMouseButton(0))
        {

            selectionRect = new Rect(startClick.x, invertMouseY(startClick.y), Input.mousePosition.x - startClick.x,
                                 invertMouseY(Input.mousePosition.y) - invertMouseY(startClick.y));

            if (selectionRect.width < 0)
            {
                selectionRect.x += selectionRect.width;
                selectionRect.width = -selectionRect.width;
            }
            if (selectionRect.height < 0)
            {
                selectionRect.y += selectionRect.height;
                selectionRect.height = -selectionRect.height;
            }
        }

    }
    public static float invertMouseY(float y)
    {
        return Screen.height - y;
    }


	
	public static GameObject[] getAllShip(string shipModel) {
        return GameObject.FindGameObjectsWithTag(shipModel); 

	}

}