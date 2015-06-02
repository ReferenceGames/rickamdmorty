using UnityEngine;
using System.Collections;

public class ShotSpawn : MonoBehaviour {
	
	
	public GameObject bullet;
	public float timer;
	public float timeBetweenBullets;
	
	void Start () 
	{
	
	}
	
	void FixedUpdate () 
	{
		timer += Time.deltaTime;
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
		
		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0 , 0 , transform.eulerAngles.z );
		
		
		if (Input.GetKey (KeyCode.Mouse0) && timer >= timeBetweenBullets)
		{
			fireWeapon();			
		}
		
	}
	
	void fireWeapon()
	{
		timer = 0f;
		Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody2D;
	}

}
