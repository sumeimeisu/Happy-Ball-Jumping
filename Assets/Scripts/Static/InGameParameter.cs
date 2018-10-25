using Assets.Scripts.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Static
{
	public static class InGameParameter
	{
		public static CharacterType CharacterType = CharacterType.Remein;
		public static int CharacterHitPoint = 30;
		public static float CharacterChangeGage = 0;
		public static bool CharacterHasBomb = false;
		public static int CharacterPowerLevel = 1;
		public static bool IsCharacterChanged = false;

		public static int CurrentPoint = 0;

		public static void Initialize ()
		{
			CharacterHitPoint = 30;
			CharacterChangeGage = 0;
			CharacterHasBomb = false;
			CharacterPowerLevel = 1;
			IsCharacterChanged = false;

			CurrentPoint = 0;
		}

		public static void EncountPoint ( int gage, int point = -1 )
		{
			if ( point == -1 )
				point = gage;

			CharacterChangeGage += gage;
			if ( CharacterChangeGage > 100 )
				CharacterChangeGage = 100;

			CurrentPoint += point;
			if ( CurrentPoint > 99999999 )
				CurrentPoint = 99999999;
		}

		public static void DiscountPoint ( int hitPoint, int point = -1 )
		{
			if ( point == -1 )
				point = hitPoint;

			CharacterHitPoint -= hitPoint;
			if ( CharacterHitPoint < 0 )
				CharacterHitPoint = 0;

			CurrentPoint -= point;
			if ( CurrentPoint < 0 )
				CurrentPoint = 0;
		}
	}
}
