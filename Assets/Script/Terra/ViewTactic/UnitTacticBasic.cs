using System;
using System.Collections;
using System.Collections.Generic;
using ZedAngular.Model.Terra;

public class UnitTacticBasic
{
    public bool _player = false;
    private int _Id;
    public int _countPlayerRow = 0;
    float _widthUnit;
    public float _positionY;
    public int _animCount = 0;
    public float _animFireCount = 0;
    public double _speed;
    public bool _tacticFire = false;
    bool _seaShip;
    bool _Infantery;
    public int _Existense;
    /*
	public List<Image> _sideitem_ar;
	public Image _imageBig;

	
	
	public GroupActor _groupActor = new GroupActor();
	public GroupActor _groupShip = new GroupActor();
	
	
	public PlayMusic _playMusic;
	
	

	public Sprite _imageTextureState;
	public Sprite _imageTextureFire;
	public Sprite _imageTextureDead;

	public string _attackSound;
	
	

	public int _animExplode = Integer.MAX_VALUE;
	public List<Texture> _explode_ar;
	public Image _imageExplode;

	public Label _textDamage;
	public Skin _mySkin;
	public enum ColorTextDamage { Red, Blue }
	*/
    public ArmUnitShip _armUnitShip;
    /*
	Image _heartPower;
	
	
	LoadBibleImage _loadBibleImage;
	ArrayList<Image> _burstImage_ar = new ArrayList<Image>();
	public Point PositionArmUnit;
	public Drawable _drawableFire;
	public Drawable _drawableDead;
	public Drawable _drawableState;
*/
    public virtual void UnitTacticBasicInit()
    {

        //_playMusic = new PlayMusic();

    }

    public int GetId()
    {
        return _Id;
    }
    /*
	public void SetId(int id)
	{
		Id = id;
	}
	*/
    public void SetUnitTactic(int countPlayer,
        float WidthScene,
        float HeightStage,

        Point sizePointUnit, bool PlayerLeft,
        int id,
        bool Infantery,
        int DividerField, TacticPlanetView tacticPlanetView)
    {
        _player = PlayerLeft;
        _Id = id;
        _countPlayerRow = countPlayer % DividerField;
        _widthUnit = sizePointUnit.X;
        _Infantery = Infantery;
        float HeightUnit = sizePointUnit.Y;
        //float startWidth = GetPositionRandomStart(PlayerLeft, WidthScene, true);

        Point sizeUnit = GetPerspective(DividerField - _countPlayerRow, _widthUnit, HeightUnit);
        _positionY = ((HeightStage / DividerField) * countPlayer) - 5 * countPlayer;

        double scaleUnit = 1.0 - ((float)countPlayer * 0.1);


        SetPositionUnitImage(sizeUnit, GetPositionRandomStart(WidthScene, true), PlayerLeft, WidthScene / DividerField,
            tacticPlanetView, (float)scaleUnit);
        //SetPositionUnitImage(sizeUnit, startWidth, PlayerLeft, WidthScene / DividerField);
    }

    public void SetUnitTactic(
            int countPlayer,
            int WidthScene,
            int HeightStage,
            Point sizePointUnit,
            bool PlayerLeft,
            int id,
            string AttackSound,
            List<Texture> Explode_ar,
            ArmUnitShip armUnitShip,
            int DividerField,
            float WidthPanelBattlePlanet
            )
    {

        _player = PlayerLeft;
        _armUnitShip = armUnitShip;

        //_sideitem_ar = new ArrayList<Image>();
        //_sideitem_ar.add(InitSetImage(ImageUnit_ar, AttackSound, true));
        //_sideitem_ar.add(InitSetImage(ImageUnit_ar, AttackSound, true));
        _seaShip = true;

        //int SizeColomn = 6;
        _countPlayerRow = countPlayer % DividerField;

        if (PlayerLeft)
        {

            //PositionArmUnit = new Point(0, DividerField - _countPlayerRow);
        }
        else
        {
            //PositionArmUnit = new Point(4, _countPlayerRow);
        }


        _widthUnit = sizePointUnit.X;
        float HeightUnit = sizePointUnit.Y;
        //PointDouble sizeUnit = GetPerspective(DividerField - _countPlayerRow, _widthUnit, HeightUnit);

        //_groupShip.addActor(_imageBig);
        //_groupShip.setHeight((float)sizeUnit.Y);
        //_imageBig.setHeight((float)sizeUnit.Y);
        ///
        // explode
        //InitExplode(Explode_ar, HeightUnit, _widthUnit, PlayerLeft);


        double PositionY = (HeightStage / DividerField) * countPlayer;//-WidthPanelBattlePlanet;

        _positionY = (float)PositionY;
        //=========
        //_groupShip.setY(-(WidthPanelBattlePlanet));
        //_groupActor.addActor(_groupShip);

        //_loadBibleImage = loadBibleImage;

        //SetSideElementShip(PlayerLeft, WidthScene / DividerField);

        //float startWidth = GetPositionRandomStart(PlayerLeft, WidthScene, false);
        _Id = id;
        //SetPositionUnitImage(sizeUnit, startWidth, PlayerLeft, WidthScene / DividerField);
        //_groupActor.Id = Id;

        //SetStageGroup(stage);
        //_groupActor.setY(_positionY);

        //
        //ButtonEvent modelEvent = new ButtonEvent();
        //modelEvent.HeroFleet = hero;
        //modelEvent.Point = new Point(0, 0);
        //modelEvent.NameEvent = ControllerConstant.SeaSelectHero;
        //modelEvent.IdHero = Id;
        //ButtonActorListerner.SetClickListenerBuilder(_groupActor, modelEvent, _groupActor.getName());

        ////

        //Image hp = initHP(loadBibleImage, _widthUnit, HeightStage / 100, _player, WidthScene / DividerField);

        //_groupActor.addActor(hp);

        //return _groupActor;
    }
    /*
	private void SetSideElementShip(boolean PlayerLeft, float Quad)
	{
		//ArrayList<CapsuleItem> CapsuleItem_ar
		ArrayList<Integer> imgNum = new ArrayList<Integer>();
		for (CapsuleItem capsuleItem:_armUnitShip.CapsuleItem_ar)
		{
			if (capsuleItem.ItemId > 1)
			{
				imgNum.add(capsuleItem.ItemId);
			}
			else
			{
				imgNum.add(1);
			}
		}


		int count = 0;
		//for(Image sideImg :_sideitem_ar)
		//{
		for (CapsuleItem capsuleItem:_armUnitShip.CapsuleItem_ar)
		{
			//if (sideImg!=null) {
			if (capsuleItem.ItemId > 1)
			{

				//BasaGoalShip basaGoalShip =new TimeSalvoConstant().GetBasaGoalTypeShip();
				//BasaGoalItem basaGoalItem0= basaGoalShip.BasaGoalItem_ar.get(imgNum[count]);
				UnitTacticGetShip unitTacticGetShip = new UnitTacticGetShip();
				//int index = (int)imgNum.get(count);
				BasaGoalItem basaGoalItem0 = unitTacticGetShip.GetBasaGoalShip(count,
						_armUnitShip.GetIdTypeShip());

				int scaleX = unitTacticGetShip.GetScale(basaGoalItem0);

				Image sideImg = UnitTexture.GetSideItemShip(capsuleItem.ItemId);

				sideImg.setScaleX(.2f * scaleX);
				sideImg.setScaleY(.2f);

				float x0 = (float)basaGoalItem0.GoalX * .2f;
				float y0 = (float)basaGoalItem0.GoalY * .2f;



				float coefX = _imageBig.getWidth() / 15;
				float coefY = _imageBig.getHeight() + _imageBig.getHeight() / 1.4f;
				float coefScale = basaGoalItem0.Scale ? sideImg.getWidth() * .2f : 0;

				float coefShipScale = 0;



				sideImg.moveBy(x0 - coefX + coefScale + coefShipScale, y0 - coefY);

				if (!PlayerLeft)
				{
					sideImg.moveBy(-_imageBig.getWidth() * .2f + Quad, 0);
				}

				_groupShip.addActor(sideImg);

				//}
			}
			count++;
		}
		//}
		///
	}
	*/
    

    private void SetHeartPower()
    {
        
    }
    
    public void TextDamageAnim(int DamageCorrect, string ColorText, List<ImprintVolley> ImprintVolleyList)
    {

       /// int damageCorrect = Mathf.Abs(DamageCorrect);
        int damageCorrect = DamageCorrect;

        if (damageCorrect == 0)
        {
            damageCorrect = 1;
        }
      


    }
   
    public void SetPositionUnitImage(Point sizeUnit, float startWidthRandom, bool PlayerLeft, float Quad,
        TacticPlanetView tacticPlanetView, float scaleUnit)
    {
        /*
        if (PlayerLeft)
        {
            tacticPlanetView.SetGameObjectPosition(_Id, sizeUnit.X, startWidthRandom, _positionY, 0,
                sizeUnit.X, scaleUnit, PlayerLeft, _Infantery);

        }
        else
        {
            tacticPlanetView.SetGameObjectPosition(_Id, -sizeUnit.X, startWidthRandom, _positionY, Quad,
                sizeUnit.X, scaleUnit, PlayerLeft, _Infantery);

        }
        */
    }

    public virtual Point GetPerspective(int range, float Width, float Height)
    {

        return new Point(Width + range * 4, Height + range * 4);
    }
    /*
    public double GetPerspectiveField(int count, int span)
    {

        return count * (span - 3 * count);
    }

        */
    public float GetPositionRandomStart(float WidthScene, bool SetRandom)
    {
        var rand = new System.Random();

        return rand.Next((int)WidthScene / 5);
        
    }

    public void SetDrawFire(float countTime)
    {
        if (_seaShip)
        {

            //SetColorCannon(Color.RED);
        }
        else
        {
            //_imageBig.setDrawable(_drawableFire);

        }
        _tacticFire = true;
        _animFireCount = countTime + 5f;

        //_playMusic.PlayMusicOperative(_attackSound);
    }
    public bool GetFireState(float CountFrame)
    {

        if (_tacticFire)
        {
            if (_animFireCount > CountFrame)
            {

                return true;
            }
            else
            {
                _tacticFire = false;
            }
        }
        return false;
    }
   
    public void SetDeadDraw()
    {
        //_imageExplode.setVisible(true);
        //_animExplode = _animCount;
    }

    public void SetDamageDraw(int Existense, List<ImprintVolley> ImprintVolleyList)
    {
        if (_seaShip)
        {
           
        }
        else
        {
            //_imageBig.setDrawable(_drawableDead);

        }
        _Existense = Existense;

        TextDamageAnim(Existense, "ColorTextDamage.Red", ImprintVolleyList);
    }

    public void DrawHP()
    {

        SetHeartPower();
    }
   
}
