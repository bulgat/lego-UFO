using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RTS {
	public static class ResourceManager {
		public static int ScrollWidth { get { return 15; } }
		public static float ScrollSpeed { get { return 25; } }
		public static float RotateAmount { get { return 10; } }
		public static float RotateSpeed { get { return 100; } }
		public static float MinCameraHeight { get { return 10; } }
		public static float MaxCameraHeight { get { return 40; } }

		private static Vector3 invalidPosition = new Vector3(-99999, -99999, -99999);
		public static Vector3 InvalidPosition { get { return invalidPosition; } }

		private static GUISkin selectBoxSkin;
		public static GUISkin SelectBoxSkin { get { return selectBoxSkin; } }
		
		public static void StoreSelectBoxItems(GUISkin skin) {
			selectBoxSkin = skin;
		}
		private static Bounds invalidBounds = new Bounds(new Vector3(-99999, -99999, -99999), new Vector3(0, 0, 0));
		public static Bounds InvalidBounds { get { return invalidBounds; } }

		private static Texture2D healthyTexture, damagedTexture, criticalTexture,damageTexture;
		public static Texture2D HealthyTexture { get { return healthyTexture; } }
		public static Texture2D DamagedTexture { get { return damagedTexture; } }
		public static Texture2D CriticalTexture { get { return criticalTexture; } }
		public static Texture2D DamageTexture { get { return damageTexture; } }

		public static void StoreSelectBoxItems(GUISkin skin, Texture2D healthy, Texture2D damaged, Texture2D critical, Texture2D damage) {
			selectBoxSkin = skin;
			healthyTexture = healthy;
			damagedTexture = damaged;
			criticalTexture = critical;
			damageTexture = damaged;
		}

		public static bool tacticMap { set; get; }
		public static List<string> Ground = new List<string>() { "Ground(Clone)","Terrain", "GroundStick(Clone)" };
		//public static List<Vector2> tileLevelPathList = new List<Vector2>(){ new Vector2(1f,0f),new Vector2(0f,1f),new Vector2(0f,-1f),new Vector2(-1f,0f) };

		
		public static float shipAltitude = 5.41f;
public static int ORDERS_BAR_WIDTH = 150;
        public const int RESOURCE_BAR_HEIGHT = 40;

    }

}