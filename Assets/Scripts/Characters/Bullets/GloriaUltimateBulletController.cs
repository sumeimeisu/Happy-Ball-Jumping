using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GloriaUltimateBulletController : PlayerBulletController
{
	private float CalculateDistance ( Vector3 a, Vector3 b )
	{
		Vector3 diff = a - b;
		return Mathf.Sqrt ( Mathf.Pow ( Mathf.Abs ( diff.x ), 2 ) + Mathf.Pow ( Mathf.Abs ( diff.y ), 2 ) );
	}

	protected override void Update ()
	{
		GameObject nearestObject = null;
		float nearestDistance = 0;
		foreach ( var obj in GameObject.FindGameObjectsWithTag ( "Enemy" ) )
		{
			if ( nearestObject == null )
			{
				nearestObject = obj;
				nearestDistance = CalculateDistance ( nearestObject.transform.position, gameObject.transform.position );
			}
			else
			{
				float distance = CalculateDistance ( obj.transform.position, gameObject.transform.position );
				if ( distance < nearestDistance )
				{
					nearestObject = obj;
					nearestDistance = distance;
				}
			}
		}

		if ( nearestObject != null )
		{
			if ( nearestDistance <= 3f )
			{
				Vector3 posDiff = nearestObject.transform.position - gameObject.transform.position;
				Angle = Mathf.Atan2 ( posDiff.y, posDiff.x ) / Mathf.PI * 180;
			}
		}

		base.Update ();
	}
}
