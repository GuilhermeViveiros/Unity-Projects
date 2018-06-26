/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audiosource;

	// Use this for initialization
	void Start () {
	
		rigidBody = GetComponent <Rigidbody2D>();
		rigidBody.velocity = Vector2.right * speed;
	}
	

	void OneCollisionEnter2D ( Collision2D col) {

		if ( (col.gameObject.name == "LeftPaddle") || (col.gameObject.name == "RightPaddle")) {

			HandlePaddleHit (col);
		}

		if ((col.gameObject.name == "WallTop") || (col.gameObject.name == "WallDown ")) {


			SoundManager.Instance.PlayOneShot (SoundManager.Instance.wallBloop);
		}

		if ((col.gameObject.name == "RightGoal") || (col.gameObject.name == "LeftGoal")) {


			SoundManager.Instance.PlayOneShot (SoundManager.Instance.goalBloop);
			// trasnforme position da me a posicao da do nome do contexto em que estou, nesto case o nome é Ball logo
			// da me as posicoes da bola
			transform.position = new Vector2 (0, 0);
		}
	}


	void HandlePaddleHit ( Collision2D col) {

		SoundManager.Instance.PlayOneShot (SoundManager.Instance.hitPaddleBloop);
		// Preciso das cordenadas da bola, do padle onde colidiu e da dimensao do padle para fazer as contas e decidir para onde mandar a bola
		float y = BallhitPaddleWhere (transform.position, col.transform.position, col.collider.bounds.size.y );


		Vector2 dir = new Vector2();

		if (col.gameObject.name == "LeftPaddle ") {

			dir = new Vector2 (1, y).normalized;
		}

		if (col.gameObject.name == "RightPaddle ") {

			dir = new Vector2 (-1, y).normalized;
		}
		rigidBody.velocity = dir * speed;
	}


	float BallhitPaddleWhere ( Vector2 ball , Vector2 paddle , float paddleHeight ) {
	
		return ( ( ball.y - paddle.y  ) / paddleHeight) ; 
	}
}


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed = 30;

	private Rigidbody2D rigidBody;

	private AudioSource audioSource;

	void Start () {

 		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = Vector2.right * speed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if ((col.gameObject.name == "LeftPaddle") || (col.gameObject.name == "RightPaddle"))
		{

			HandlePaddleHit(col);

		}


		if ((col.gameObject.name == "WallDown") || (col.gameObject.name == "WallTop"))
		{
			// Play the sound effect
			SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
		}

		if ((col.gameObject.name == "LeftGoal") || (col.gameObject.name == "RightGoal"))
		{
	
			if (col.gameObject.name == "LeftGoal") {
			
				IncreseScore ("RightScoreUI"); 

				SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

				transform.position = new Vector2(0, 0);
				rigidBody.velocity = new Vector2 (1, 0)*speed;
					}

			if (col.gameObject.name == "RightGoal") {

				IncreseScore ("LeftScoreUI"); 

				SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

				transform.position = new Vector2(0, 0);
				rigidBody.velocity = new Vector2 (-1, 0)*speed;
			}
				

		}

	}

	void HandlePaddleHit(Collision2D col)
	{

		// col.collider.bounds.size.y da me a altura do meu paddle completo
		float y = BallHitPaddleWhere(transform.position, col.transform.position,	col.collider.bounds.size.y);

		// Vector ball moves to
		Vector2 dir = new Vector2();


		if(col.gameObject.name == "LeftPaddle")
		{
			dir = new Vector2(1, y).normalized;
		}

		if (col.gameObject.name == "RightPaddle")
		{
			dir = new Vector2(-1, y).normalized;
		}

		rigidBody.velocity = dir * speed;

	
		SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);

	}

	// Find y for the ball vector based
	// on where the ball hit the paddle
	float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
	{
		return (ball.y - paddle.y) / paddleHeight;
	}


	void IncreseScore ( string textUIName ) {
		// estou a retirar o text ui que tenho para a pontuacao 
		// uso o GameObject procurao o nome e tiro de la o texto
		var textUIComp = GameObject.Find (textUIName).GetComponent<Text> ();

		// transforma me da minha string para o meu int
		int score = int.Parse (textUIComp.text);
		score++;

		// transforma me do meu int para a minha string;
		textUIComp.text = score.ToString();
	}
}
 