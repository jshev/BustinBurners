using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
	public GameObject circleCustomer;
	public GameObject squareCustomer;

	// Use this for initialization
	void Start () {
		/* if (gameObject.name == "leftSpawner") {
			InvokeRepeating("launchRight", 0f, 6f);
		} else {
			InvokeRepeating("launchLeft", 2f, 8f);
		} */
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name == "leftSpawner") {
			//InvokeRepeating("launchRight", 0f, 5f);
			if (GameObject.FindGameObjectsWithTag ("circleCustomer").Length == 0) {
				launchRight ();
			}
		} else {
			//InvokeRepeating("launchLeft", 3f, 8f);
			if (GameObject.FindGameObjectsWithTag ("squareCustomer").Length == 0) {
				launchLeft ();
			}
		}
	}

	void launchLeft() {
		// instantiate new cells from spawner
		GameObject passerby = Instantiate(squareCustomer) as GameObject;
		passerby.transform.position = transform.position;
	}

	void launchRight() {
		// instantiate new cells from spawner
		GameObject passerby = Instantiate(circleCustomer) as GameObject;
		passerby.transform.position = transform.position;
	}
}
