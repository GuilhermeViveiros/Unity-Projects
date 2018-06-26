using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2Paddle : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	public float tweaklerp = 2f;

	public Ball bola;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if ( bola.transform.position.x > transform.position.x ) {

			Vector2 dir = new Vector2 (1, 0);
			// time.delta time , da me a distancia entre dois pontos por cada frama
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, tweaklerp * Time.deltaTime);


		}

		else if ( bola.transform.position.x < transform.position.x ) {
	
			Vector2 dir = new Vector2 (-1, 0);
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, tweaklerp * Time.deltaTime);
	}
		else {
			Vector2 dir = new Vector2 (0, 0);
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, tweaklerp * Time.deltaTime);
		}
 }
}
