using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		var addAngle = 270;
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;

		// 450 250
		if(angle > 270 && angle < 450)
		{
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
