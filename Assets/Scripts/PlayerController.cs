using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float xSens = 1.0f;
	public float ySens = 1.0f;
	public bool xInvert = false;
	public bool yInvert = false;

	public float moveSpeed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
		Look();
		Walk();
    }

	void Look()
	{
		float yRot = Input.GetAxis("Mouse Y") * ySens * -1;
		float xRot = Input.GetAxis("Mouse X") * xSens;

		yRot = yInvert ? yRot * -1 : yRot;
		xRot = xInvert ? xRot * -1 : xRot;

		transform.Rotate(yRot, xRot, 0);

		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
	}

	void Walk()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, moveSpeed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Lava")
		{
			transform.position = new Vector3(0, 0, 0);
		}
	}
}
