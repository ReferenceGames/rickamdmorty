using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float movement;
	
	
	// Use this for initialization
	void Start () 
	{
	
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
			Vector2 newPosition = new Vector2(transform.position.x + movement, transform.position.y);
			transform.position = newPosition;
		}
		
	}
	
	
}
