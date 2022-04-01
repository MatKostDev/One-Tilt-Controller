using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
	[SerializeField]
	private string hAxisName;

	[SerializeField]
	private string vAxisName;

	[SerializeField]
	private float maxAxisRotation = 30f;

	private void Update()
	{
		float hAxis = Input.GetAxis(hAxisName);
		Debug.Log(hAxis);
		if (Mathf.Abs(hAxis) > 0.1f)
		{
			float multiplier = hAxis > 0f ? -1f : 1f;

			Vector3 newEulers = transform.eulerAngles;
			newEulers.y = Mathf.Lerp(0f, maxAxisRotation * multiplier, 1f / Mathf.Abs(hAxis));

			transform.rotation = Quaternion.Euler(newEulers);
		} 
		else
		{
			Vector3 newEulers = transform.eulerAngles;
			newEulers.y = 0f;

			transform.rotation = Quaternion.Euler(newEulers);
		}

		float vAxis = Input.GetAxis(vAxisName);
		Debug.Log(vAxis);
		if (Mathf.Abs(vAxis) > 0.1f)
		{
			float multiplier = vAxis > 0f ? 1f : -1f;

			Vector3 newEulers = transform.eulerAngles;
			newEulers.x = Mathf.Lerp(0f, maxAxisRotation * multiplier, 1f / Mathf.Abs(vAxis));

			transform.rotation = Quaternion.Euler(newEulers);
		}
		else
		{
			Vector3 newEulers = transform.eulerAngles;
			newEulers.x = 0f;

			transform.rotation = Quaternion.Euler(newEulers);
		}
		Debug.Log("--------");
	}
}
