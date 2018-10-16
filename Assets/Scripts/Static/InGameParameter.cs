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
		public static CharacterType CharacterType;
		public static int CharacterHitPoint = 30;
		public static int CharacterChangeGage = 0;
		public static bool CharacterHasBomb = false;
		public static int CharacterPowerLevel = 1;

		public static int CurrentPoint = 0;
	}
}
