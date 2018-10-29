using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Options
{
	[Serializable]
	struct OptionPref
	{
		public bool TurnOnAudio, TurnOnVib;
	}

	public static bool TurnOnAudio = true;
	public static bool TurnOnVibration = true;

	static Options ()
	{
		Load ();
	}

	public static void Load ()
	{
		if ( !File.Exists ( Application.persistentDataPath + "/savedOption.bin" ) )
			return;

		BinaryFormatter bf = new BinaryFormatter ();
		using ( FileStream file = File.OpenRead ( Application.persistentDataPath + "/savedOption.bin" ) )
		{
			OptionPref saved = ( OptionPref ) bf.Deserialize ( file );
			TurnOnAudio = saved.TurnOnAudio;
			TurnOnVibration = saved.TurnOnVib;
		}
	}

	public static void Save ()
	{
		Debug.Log ( "Save path: " + Application.persistentDataPath + "/savedOption.bin" );

		BinaryFormatter bf = new BinaryFormatter ();
		using ( FileStream file = File.Create ( Application.persistentDataPath + "/savedOption.bin" ) )
		{
			bf.Serialize ( file, new OptionPref () { TurnOnAudio = TurnOnAudio, TurnOnVib = TurnOnVibration } );
		}
	}
}
