using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neo : MonoBehaviour {

	Vector3 deltaPos;
	public float speed = 1;
	public float gravity = .1f;
	public float jumpPower = .5f;

    bool growing = false;
    Vector3 growStart, growEnd;
    float growTime = 0f;
    float growProgress = 0f;

	// Use this for initialization
	void Start () {
        growStart = growEnd = new Vector3(1, 1, 1);
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

		if (Input.GetKeyDown (KeyCode.Space) && System.Math.Abs(transform.position.y) < Mathf.Epsilon) {
			deltaPos.y += jumpPower;
		}

		if (transform.position.y > 0)
			deltaPos.y -= gravity;

//		if (transform.position.y + deltaPos.y <= 0)
//			deltaPos.y = -deltaPos.y;

		transform.position += deltaPos;
		if (transform.position.y < 0)
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

        //Grow
        if (growing){
            growProgress += Time.deltaTime;
            transform.localScale = Vector3.Lerp(growStart, growEnd, growProgress / growTime);
            if (growProgress > growTime)
            {
                growing = false;
                growTime = 0f;
                growProgress = 0f;
                //growStart = growEnd = transform.localScale;
            }
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        print("Entered Trigger");
		if (other.tag == "PowerUp")
        {
            growStart = transform.localScale;
            growEnd *= 2;
            if (growTime == 3f)
                growTime *= 2f;
            else
                growTime = 3f;
            //growProgress = 0f;
            growing = true;
            Destroy(other.gameObject.transform.parent.gameObject);
        }
	}
}
