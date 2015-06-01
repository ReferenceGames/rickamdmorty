using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;
	Vector3 mousePosition;
	Vector3 direction;
	
	
	void Start () 
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0.0f;
		direction = (mousePosition - transform.position).normalized;
	}
	
	void FixedUpdate () 
	{
		transform.position += direction * speed * Time.deltaTime;
	}
}
