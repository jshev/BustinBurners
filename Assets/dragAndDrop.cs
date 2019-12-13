using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndDrop : MonoBehaviour {

	Vector3 screenPoint;
	Vector3 offset;

	Vector2 defaultPos;
	string myCustomer;
	string notMyCustomer;
	public GameObject scoreMan;

	// Use this for initialization
	void Start () {
		defaultPos = transform.localPosition;

		switch (gameObject.tag)
		{
		case "circleFood":
			myCustomer = "circleCustomer";
			notMyCustomer = "squareCustomer";
			break;
		case "squareFood":
			myCustomer = "squareCustomer";
			notMyCustomer = "circleCustomer";
			break;

		default:
			Debug.Log(gameObject.name + " has no customer!");
			break;
		}
		
	}

	// OnMouseDown and OnMouseDrag allow the cards to be clicked and dragged in the game window
	// got code from http://coffeebreakcodes.com/drag-object-with-mouse-unity3d/
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseUp() {
		transform.position = defaultPos;

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null) {
			if (hit.transform.tag == myCustomer) {
				scoreMan.GetComponent<scoreManager> ().addPoints ();
				hit.transform.gameObject.GetComponent<customerController> ().keepWalking ();
				//hit.transform.gameObject.SetActive (false);
				gameObject.SetActive (false);
			} else if (hit.transform.tag == notMyCustomer) {
				scoreMan.GetComponent<scoreManager> ().subtractPoints ();
				hit.transform.gameObject.GetComponent<customerController> ().keepWalking ();
				//hit.transform.gameObject.SetActive (false);
				//gameObject.SetActive (false);
			}
		}
	}
}
