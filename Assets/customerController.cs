using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerController : MonoBehaviour {

	public GameObject elipse;
	scoreManager scoreMan;
	Rigidbody2D rb;
	SpriteRenderer sr;
	Vector2 velocity;
	float timeLeft;
	bool once = false;
	bool once2 = false;

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		scoreMan = FindObjectOfType<scoreManager>();
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		elipse.SetActive (false);

		if (gameObject.tag == "squareCustomer") {
			velocity = new Vector2 (-5f, 0f);
		} else {
			velocity = new Vector2 (5f, 0f);
		}
		timeLeft = Random.Range (0.5f, 2.5f);

	}
	
	// Update is called once per frame
	void Update () {
		
		rb.MovePosition(rb.position + velocity * Time.deltaTime);
		if (gameObject.tag == "squareCustomer") {
			/* if (transform.position.x > 2.9 && transform.position.x < 3) {
				stop ();
			} */
			if (transform.position.x < -9f) {
				Destroy (gameObject);
			}
		} else {
			/* if (transform.position.x < -2.9 && transform.position.x > -3) {
				stop ();
			} */
			if (transform.position.x > 9f) {
				Destroy (gameObject);
			}
		}

		timeLeft -= Time.deltaTime;
		if (timeLeft < 0 && !once)
		{
			stop ();
			once = true;
		}
		if (timeLeft < -5 && !once2)
		{
			if (velocity.x == 0f && velocity.y == 0f) {
			keepWalking ();
			scoreMan.subtractPoints();
			once2 = true;
			}
		}

		//print(GameObject.FindGameObjectsWithTag("circleFood").Length);
	}

	void stop() {
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		velocity = new Vector2 (0f, 0f);
		elipse.SetActive (true);
	}

	public void keepWalking() {
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		if (gameObject.tag == "squareCustomer") {
			elipse.SetActive (false);
			velocity = new Vector2 (-5f, 0f);
		} else {
			elipse.SetActive (false);
			velocity = new Vector2 (5f, 0f);
		}
	}

}
