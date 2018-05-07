using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float playerSpeed;
	public bool onGround;
	private Rigidbody2D player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 move = new Vector2 (moveHorizontal * playerSpeed, moveVertical * playerSpeed);
		player.velocity = move;
	}
}
