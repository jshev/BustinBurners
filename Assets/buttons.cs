using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	public void play() {
		SceneManager.LoadScene ("Scene");
	}

	public void menu() {
		SceneManager.LoadScene ("Menu");
	}
}
