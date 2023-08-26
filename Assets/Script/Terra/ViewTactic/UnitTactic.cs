using System.Collections;
using System.Collections.Generic;

using System;

public class UnitTactic : UnitTacticBasic
{
	
	int _countPlayer;
	int _rowIndex = 0;
	bool _dead = false;
	private float _staticSpeed;
	public UnitTactic(bool PlayerLeft, int countPlayer, float WidthScene, 
		float MinSpeed,
		float Speed,
		Point sizePointUnit) 
	{
        _player = PlayerLeft;
		_countPlayer = countPlayer;
		int SizeColomn = 6;
		_countPlayerRow = countPlayer % SizeColomn;
		if (countPlayer > 0)
		{
			_rowIndex = countPlayer / SizeColomn;
		}


		float widthUnit = sizePointUnit.X;
		float HeightUnit = sizePointUnit.Y;
		
		Point sizeUnit = GetPerspective(SizeColomn - _countPlayerRow, widthUnit, HeightUnit);

		float startWidth = GetPositionRandomStart(PlayerLeft, WidthScene, true);

	
		_staticSpeed = GetRandomSpeed(MinSpeed, Speed);
		_speed = _staticSpeed;
		SetPositionUnit(PlayerLeft);
	}
	private float GetRandomSpeed(float minSpeed, float speed)
	{
		var rand = new System.Random();
		var kol = (float)(minSpeed + rand.Next((int)speed) + 0.1);
		
		return kol;

		//return minSpeed + Math.random() * speed + 0.1;
	}
	
	public float GetPositionRandomStart(bool Player, float WidthScene, bool SetRandom)
	{
		double startWidth = 0.1f;

		if (SetRandom)
		{
			var rand = new System.Random();
			//startWidth = Math.random() * (WidthScene / 15);
			WidthScene = rand.Next((int)WidthScene/15);
		}
		if (Player)
		{
			return (float)startWidth;
		}
		return (float)(WidthScene - startWidth);

	}
	private void SetPositionUnit(bool player)
	{
		
		if (player)
		{

		}
		else
		{
	
		}
			//_staticSpeed = unitTacticGreat._staticSpeed;
	
	}

	public void SetDead(int Damage)
	{
		SetDamageDraw(Damage, null);

		_speed = 0;
		_dead = true;
		SetDeadDraw();

		//TextDamageAnim(Damage, ColorTextDamage.Red, null);

	}

	public void SetFire(float AnimCount)
	{
		
		SetDrawFire(AnimCount);

		//_animFire = _animCount;
		// infantery?
		if (_tacticFire)
		{
			_speed = 0;

		}

	}
	public void DrawUnit(TacticPlanetView tacticPlanetView, float CountFrame,int Damage)
	{
		
		if (_dead == false)
		{

			if (GetFireState(CountFrame)==false)
			{

				_speed = _staticSpeed;
			}
		
		}
		else
		{
	
		}
	
		if (StopMiddleScene())
		{

		}
		else
		{
			

			///tacticPlanetView.MoveByUnit((float)_speed,GetId(), _player,_dead, GetFireState(CountFrame),Damage);
	

		}
		
		
	}
	public bool StopMiddleScene()
	{

		return false;
	}

}
