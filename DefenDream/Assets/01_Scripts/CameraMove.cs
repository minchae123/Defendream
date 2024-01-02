using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float speed = 5;

	private void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		Vector3 dir = new Vector2(x, 0).normalized;

		Vector3 pos = transform.position + dir * Time.deltaTime * speed;

		pos.x = Mathf.Clamp(pos.x, -15, 40);

		transform.position = pos;
	}
}
