using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour {

	public Ball theBall;

	public float speed = 30;

	public float lerptweak = 2f;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent <Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//quando a posicao da bola for maior que a posicao do paddle
		if ( theBall.transform.position.y > transform.position.y) {

			Vector2 dir = new Vector2 (0, 1).normalized;
			// timedelta tiime mete o meu padle numa certa distancia em funcao do meu frame rate
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, lerptweak * Time.deltaTime);
	
		} else if ( theBall.transform.position.y < transform.position.y) {

			Vector2 dir = new Vector2 (0, -1).normalized;
			// timedelta tiime mete o meu padle numa certa distancia em funcao do meu frame rate
			// por exemplo do vetor (0,1) ate (0,30)
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, lerptweak * Time.deltaTime);
		} 
		else {
			Vector2 dir = new Vector2 (0,0).normalized ;
			rigidBody.velocity = Vector2.Lerp (rigidBody.velocity, dir * speed, lerptweak * Time.deltaTime);
		} 

	}

}
