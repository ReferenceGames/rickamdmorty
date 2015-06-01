using UnityEngine;
using System.Collections;

public class SwipeControls : MonoBehaviour 
{
	public GameObject player; // Drag your player here
	public float movement;
	private Vector2 fp; // first finger position
	private Vector2 lp; // last finger position
	private float angle;
	private float swipeDistanceX;
	private float swipeDistanceY;
	private RaycastHit hit;
	private bool touching = false;
	
	void Update () 
	{
		foreach(Touch touch in Input.touches)
		{
			var ray = Camera.main.ScreenPointToRay(touch.position);
			if (Physics.Raycast(ray, out hit))
			{
				touching = true;
			}
			if(touching)
			{
				if (touch.phase == TouchPhase.Began)
				{
					fp = touch.position;
					lp = touch.position;
				}
						
				if (touch.phase == TouchPhase.Moved )
				{
					lp = touch.position;
					swipeDistanceX = Mathf.Abs((lp.x-fp.x));
					swipeDistanceY = Mathf.Abs((lp.y-fp.y));
				}
				if(touch.phase == TouchPhase.Ended)
				{
					angle = Mathf.Atan2((lp.x-fp.x),(lp.y-fp.y))*57.2957795f;
					
					if(angle > 60 && angle < 120 && swipeDistanceX > 40    )
					{
						print ("right");
						player.transform.position += new Vector3 (movement, 0, 0);
					}
					if(angle > 150 || angle < -150 && swipeDistanceY > 40)
					{
						print ("down");
						player.transform.position += new Vector3 (0,-movement, 0);
					}
					if(angle < -60 && angle > -120 && swipeDistanceX > 40)
					{
						print ("left");
						player.transform.position += new Vector3 (-movement, 0, 0);
					}
					if(angle > -30 && angle < 30 && swipeDistanceY > 40)
					{
						print ("up");
						player.transform.position += new Vector3 (0, movement, 0);
					}
					if(angle >= 30 && angle <= 60 && swipeDistanceX > 40  && swipeDistanceY > 40  )
					{
						print ("Up and right");
						player.transform.position += new Vector3 (movement, movement, 0);
					}
					if(angle <= -30 && angle >= -60 && swipeDistanceX > 40 && swipeDistanceY > 40 )
					{
						print ("Up and left");
						player.transform.position += new Vector3 (-movement, movement, 0);
					}
					if(angle >= 120 && angle <= 150 && swipeDistanceX > 40  && swipeDistanceY > 40  )
					{
						print ("Down and right");
						player.transform.position += new Vector3 (movement, -movement, 0);
					}
					if(angle >= -150 && angle <= -120 && swipeDistanceX > 40  && swipeDistanceY > 40  )
					{
						print ("Down and left");
						player.transform.position += new Vector3 (-movement, -movement, 0);
					}
					touching = false;
				}	
			}		
		}
	}
}
