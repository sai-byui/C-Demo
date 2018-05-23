using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neo : MonoBehaviour {

	Vector3 deltaPos;
	public float speed = 1;
	public float gravity = .1f;
	public float jumpPower = .5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		deltaPos.x = 0;
		deltaPos.z = 0;

		if (Input.GetKey (KeyCode.UpArrow))
			deltaPos.z = speed;
		if (Input.GetKey (KeyCode.DownArrow))
			deltaPos.z = -speed;
		if (Input.GetKey (KeyCode.LeftArrow))
			deltaPos.x = -speed;
		if (Input.GetKey (KeyCode.RightArrow))
			deltaPos.x = speed;

		if (Input.GetKeyDown (KeyCode.Space) && transform.position.y == 0) {
			deltaPos.y += jumpPower;
		}

		if (transform.position.y > 0)
			deltaPos.y -= gravity;

//		if (transform.position.y + deltaPos.y <= 0)
//			deltaPos.y = -deltaPos.y;

		transform.position += deltaPos;
		if (transform.position.y < 0)
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
	}
}
