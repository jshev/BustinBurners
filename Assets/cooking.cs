using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// progress bar functionality courtesy of Jonah Warren

public class cooking : MonoBehaviour {
	
	// variables for various game objects
	public GameObject progressBar;
	public GameObject dish1;
	public GameObject dish2;
	public GameObject dish3;
	float initialXScale;

	// other variables
	int numHitsRequired = 3;
	int numHits = 0;
	bool once = false;
	int numDishes = 0;

	// Use this for initialization
	void Start () {

		// already altered the x scale in the editor, so need to get what that is
		initialXScale = progressBar.transform.localScale.x;

		// reset it to zero so there is no bar initially
		progressBar.transform.localScale = new Vector2(0, progressBar.transform.localScale.y);
		
		// add a hit every second, starting on start
		InvokeRepeating ("CountDown", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.tag == "circlePot") {
			numDishes = GameObject.FindGameObjectsWithTag ("circleFood").Length;
		} else {
			numDishes = GameObject.FindGameObjectsWithTag ("squareFood").Length;
		}

		// if the bar is full
		if (numHits >= numHitsRequired) {
			if (!once) {
				loadNextFood ();
				numHits = numHitsRequired;
				once = true;
			} else {
				numHits = numHitsRequired;
			}
			// load end scene
			//SceneManager.LoadScene ("End");
		}

		// calculate percentage done (a number between 0 and 1)
		float pecentDone = numHits*1.0f/numHitsRequired;

		// multiply the percentage by the original scale (of what the bar looks like full)
		progressBar.transform.localScale = new Vector2(pecentDone * initialXScale, progressBar.transform.localScale.y);
		
	}

	void OnMouseDown(){
		if (numHits == numHitsRequired) {
			numHits = 0;
			once = false;
		}
	}

	void CountDown() {
		numHits++;
	}

	void ResetHits() {
		numHits = 0;
	}

	void loadNextFood() {
		switch (numDishes)
		{
		// tutorial cards
		case 0:
			dish1.SetActive (true);
			break;
		case 1:
			dish1.SetActive (true);
			dish2.SetActive (true);
			break;
		case 2:
			dish1.SetActive (true);
			dish2.SetActive (true);
			dish3.SetActive (true);
			break;
		default:
			Debug.Log("Full on dishes");
			break;
		}
	}
}
