using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float movement;
	public Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			Vector2 newPosition = new Vector2(transform.position.x, transform.position.y + movement);
			transform.position = newPosition;
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - movement);
			transform.position = newPosition;
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			Vector2 newPosition = new Vector2(transform.position.x - movement, transform.position.y);
			transform.position = newPosition;
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			anim.SetTrigger( "jumpForwardTrigger" );
			Vector2 newPosition = new Vector2(transform.position.x + movement, transform.position.y);
			transform.position = newPosition;
		}

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}

		Animating ();
	}

	void Animating ()
	{
		//GetComponent<Animator>().SetBool("IsWalking", true);
	}

}
