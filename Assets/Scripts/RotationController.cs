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
	private float maxAxisRotation = 50f;

	private void Update()
	{
		float hAxis = Input.GetAxisRaw(hAxisName);
		if (Mathf.Abs(hAxis) > 0.1f)
		{
			float multiplier = hAxis > 0f ? 1f : -1f;

			Vector3 newEulers = transform.eulerAngles;
			newEulers.y = Mathf.Lerp(0f, maxAxisRotation * multiplier, 1f / hAxis);

			transform.eulerAngles = newEulers;
		}

		float vAxis = Input.GetAxisRaw(vAxisName);
		if (Mathf.Abs(vAxis) > 0.1f)
		{
			float multiplier = vAxis > 0f ? 1f : -1f;

			Vector3 newEulers = transform.eulerAngles;
			newEulers.x = Mathf.Lerp(0f, maxAxisRotation * multiplier, 1f / vAxis);

			transform.eulerAngles = newEulers;
		}
	}
}
