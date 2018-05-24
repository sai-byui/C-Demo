using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

    public GameObject item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < 5; i++)
            {
                float x, z;
                Vector3 spawnPos;
                x = Random.Range(-4.5f, 4.5f);
                z = Random.Range(-4.5f, 4.5f);
                spawnPos = new Vector3(x, 0, z);

                Instantiate(item, spawnPos, Quaternion.identity);
            }
        }
	}
}
