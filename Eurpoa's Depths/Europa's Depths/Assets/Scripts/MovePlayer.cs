using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float playerSpeed = 20;
    public float jumpPower = 6.5f;
    public float maxSpeed = 5;
	public float laserSpeed = 750;
	public bool isGrounded = true;
	public GameObject laser;

    private float moveHorizontal, moveVertical;
    private Rigidbody2D player;
    private Vector2 move, jump;
	private AudioSource laserBlast;


	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D> ();
        jump = new Vector2(0.0f, 1.0f);
		laserBlast = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        // Check for jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            player.AddForce(jump * jumpPower, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Check for Laser
		if (Input.GetKeyDown(KeyCode.F))
        {
			// Play Sound
			laserBlast.Play();
			// Spawn Laser Object
			StartCoroutine(SpawnLaserBlast());
        }

        // Get Movement Input
        moveHorizontal = Input.GetAxis("Horizontal");
		if (isGrounded)
		{
			move = new Vector2(moveHorizontal * playerSpeed, 0);
		}else{
			move = new Vector2(moveHorizontal * playerSpeed * 0.5f, 0);
		}

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if( collision.collider.tag == "ground")
		    isGrounded = true; 
    }

	IEnumerator SpawnLaserBlast()
	{
		GameObject laserInstance;
		Vector2 currentPosition = transform.position;

		laserInstance = Instantiate(laser, currentPosition, Quaternion.identity);

		laserInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(laserSpeed, 0));
		laserInstance.transform.Rotate(new Vector3(0, 0, 270));

		yield return new WaitForSeconds(3);
		Destroy(laserInstance);
	}
}
