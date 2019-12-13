using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour {
	int score;
	public Text scoreTxt;

	// Use this for initialization
	void Start () {
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		scoreTxt.text = "Score: " + score;

		if (score < -500) {
			SceneManager.LoadScene ("Fired");
		}
	}

	public void addPoints() {
		score = score + 50;
	}

	public void subtractPoints() {
		score = score - 100;
	}

}
