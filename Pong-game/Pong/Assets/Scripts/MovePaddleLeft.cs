using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddleLeft : MonoBehaviour {

	public float speed = 30;

	void FixedUpdate(){

		float vertPress = Input.GetAxisRaw ("Vertical");
		float vertPress2 = Input.GetAxisRaw ("Horizontal");

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (vertPress2, vertPress) * speed;
	

	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}