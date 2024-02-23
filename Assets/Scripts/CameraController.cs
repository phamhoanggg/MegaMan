using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public float followSpeed;
	public GameObject target;
	public Vector3 offset;

	// Update is called once per frame
	void LateUpdate()
	{
		if (target)
		{

			transform.position = target.transform.position + offset;

		}
	}
}
