using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownPaddle : MonoBehaviour {

	public float speed = 30;

	void FixedUpdate(){

		float vertPress = Input.GetAxisRaw ("Horizontal");

		GetComponent<Rigidbody2D> ().velocity = new Vector2 ( vertPress , 0) * speed;

	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
