using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float playerSpeed = 15;
    public float jumpPower = 5;
    public float maxSpeed = 5;

    private float moveHorizontal, moveVertical;
    private Rigidbody2D player;
    private Vector2 move, jump;
    public bool isGrounded = true;


	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D> ();
        jump = new Vector2(0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        // Check for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            player.AddForce(jump * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Get Movement Input
        moveHorizontal = Input.GetAxis("Horizontal");
        if(isGrounded){
            move = new Vector2(moveHorizontal * playerSpeed, 0);
            player.AddForce(move, ForceMode2D.Force);

            if (player.velocity.x > maxSpeed)
            {
                move = new Vector2(maxSpeed, player.velocity.y);
                player.velocity = move;
            }
            else if (player.velocity.x < (-1 * maxSpeed))
            {
                move = new Vector2((-1 * maxSpeed), player.velocity.y);
                player.velocity = move;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
