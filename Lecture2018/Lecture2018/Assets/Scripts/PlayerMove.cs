using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float playerSpeed = 5;
	public bool onGround;
    public bool useForce = false;
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
        if( useForce )
            player.AddForce(move);
        else
            player.velocity = move;
	}
}
